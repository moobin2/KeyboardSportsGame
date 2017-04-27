using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnermyGender
{
    Male, Female
}

public enum EnermyType
{
    Warrior, Archer
}

public class Controller_EnemyBase : Controller_Base
{
    public GameObject       hairPos;            // 헤어 위치
    public GameObject       rightHandPos;       // 오른손 위치
    public GameObject       leftHandPos;        // 왼손 위치
    public float            moveSpeed;          // 이동 속도
    public float            attackRange;        // 공격 범위

    protected EnermyGender  _gender;            // 몬스터 성별
    protected EnermyType    _type;              // 몬스터 타입
    protected GameObject    _player;            // 플레이어
    protected float         _waitingTime;       // 어택타임
    protected bool          _bIsAttack = false; // 공격여부

    protected void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void Init()
    {
        SetEnemySkin();
        base.Init();
    } 

    protected void SetEnemySkin()
    {
        string enermyContainerPath = "Enermy/";
        _gender = (EnermyGender)Random.Range(0, 2);

        SetEnermyHair(enermyContainerPath, _gender);
        SetEnermyBody(enermyContainerPath, _gender);
    }

    void SetEnermyHair(string enermyContainerPath, EnermyGender gender)
    {
        // Hair 게임오브젝트 불러와서 랜덤한것 붙여준다.
        GameObject[] arrEnermyHair = Resources.LoadAll<GameObject>(enermyContainerPath + "Hair/" + gender.ToString());

        GameObject Hair = Instantiate(arrEnermyHair[Random.Range(0, arrEnermyHair.Length)]);
        Hair.transform.parent = hairPos.transform;
        Hair.transform.localPosition = Vector3.zero;
        Hair.transform.localRotation = Quaternion.identity;
        Hair.transform.localScale = Vector3.one;
    }

    void SetEnermyBody(string enermyContainerPath, EnermyGender gender)
    {
        // Body 텍스쳐 불러와서 랜덤한것 붙여준다.
        Material[] EnermyBody = Resources.LoadAll<Material>(enermyContainerPath + "Body/" + gender.ToString());

        GameObject Base = this.transform.FindChild("Base").gameObject as GameObject;
        SkinnedMeshRenderer BaseSkin = Base.GetComponent<SkinnedMeshRenderer>();
        BaseSkin.material = EnermyBody[Random.Range(0, EnermyBody.Length)];
    }

    protected void RotateToPlayer()
    {
        Vector3 playerDirection = (_player.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(playerDirection, Vector3.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // 외적을 이용해 -180~180의 각도로 계산
        Vector3 temp = Vector3.Cross(Vector3.forward, playerDirection).normalized;
        angle = (temp.y > 0) ? angle : -angle;

        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, angle, 0), "easeType", "Linear", "time", 0.2f, "oncomplete", "FollowRotatePlayer"));
    }

    IEnumerator FollowRotatePlayer()
    {
        float time = 0.0f;
        while (true)
        {
            // 궁수라면
            if(_type == EnermyType.Archer)
            {
                time += Time.deltaTime;
                if (time < 2.0f)
                {
                    this.transform.LookAt(_player.transform);
                    Quaternion currentRotate = this.transform.rotation;
                    currentRotate.x = 0;
                    this.transform.rotation = currentRotate;
                    yield return null;
                }
                else
                {
                    yield return StartCoroutine("AttackToPlayer");
                    break;
                }
            }
            // 전사라면
            else
            {
                if ((this.transform.position - _player.transform.position).magnitude > attackRange)
                {
                    // 회전을 시킨다. 
                    this.transform.LookAt(_player.transform);
                    Quaternion currentRotate = this.transform.rotation;
                    currentRotate.x = 0;
                    this.transform.rotation = currentRotate;

                    // 이동을 한다.
                    Vector3 dir = (_player.transform.position - this.transform.position).normalized;
                    this.transform.position += dir * moveSpeed;

                    yield return null;
                }
                else
                {
                    yield return StartCoroutine("AttackToPlayer");
                    break;
                }
            }
        }
    }
}
