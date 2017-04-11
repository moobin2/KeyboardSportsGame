using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyGender
{
    Male, Female
}

public class Controller_EnemyBase : MonoBehaviour
{
    public GameObject hairPos;              // 헤어 위치
    public GameObject rightHandPos;         // 오른손 위치
    public GameObject leftHandPos;          // 왼손 위치

    protected EnemyGender _gender;          // 몬스터 성별
    protected GameObject _player;           // 플레이어
    protected float _attackTime;            // 어택타임
    protected bool _bIsAttack = false;      // 공격여부

    protected void Start ()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        SetEnemySkin();
    }

    protected void SetEnemySkin()
    {
        string enermyContainerPath = "Enermy/";
        _gender = (EnemyGender)Random.Range(0, 2);

        SetEnermyHair(enermyContainerPath, _gender);
        SetEnermyBody(enermyContainerPath, _gender);
    }

    void SetEnermyHair(string enermyContainerPath, EnemyGender gender)
    {
        // Hair 게임오브젝트 불러와서 랜덤한것 붙여준다.
        GameObject[] arrEnermyHair = Resources.LoadAll<GameObject>(enermyContainerPath + "Hair/" + gender.ToString());

        GameObject Hair = Instantiate(arrEnermyHair[Random.Range(0, arrEnermyHair.Length)]);
        Hair.transform.parent = hairPos.transform;
        Hair.transform.localPosition = Vector3.zero;
        Hair.transform.localRotation = Quaternion.identity;
        Hair.transform.localScale = Vector3.one;
    }

    void SetEnermyBody(string enermyContainerPath, EnemyGender gender)
    {
        // Body 텍스쳐 불러와서 랜덤한것 붙여준다.
        Material[] EnermyBody = Resources.LoadAll<Material>(enermyContainerPath + "Body/" + gender.ToString());

        GameObject Base = this.transform.FindChild("Base").gameObject as GameObject;
        SkinnedMeshRenderer BaseSkin = Base.GetComponent<SkinnedMeshRenderer>();
        BaseSkin.material = EnermyBody[Random.Range(0, EnermyBody.Length)];
    }

    //protected float AngleToPlayer()
    //{
    //    // 플레이어 위치에 따른 각도 계산
    //    Vector3 playerDirection = (_player.transform.position - transform.position).normalized;
    //    float dot = Vector3.Dot(playerDirection, Vector3.forward);
    //    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

    //    // 외적을 이용해 -180~180의 각도로 계산
    //    Vector3 temp = Vector3.Cross(Vector3.forward, playerDirection).normalized;
    //    angle = (temp.y > 0) ? angle : -angle;

    //    return angle;
    //}

    protected void RotateToPlayer()
    {
        Vector3 playerDirection = (_player.transform.position - transform.position).normalized;
        float dot = Vector3.Dot(playerDirection, Vector3.forward);
        float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        // 외적을 이용해 -180~180의 각도로 계산
        Vector3 temp = Vector3.Cross(Vector3.forward, playerDirection).normalized;
        angle = (temp.y > 0) ? angle : -angle;

        iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, angle, 0), "easeType", "Linear", "time", 0.2f, "oncomplete", "AttackToPlayer"));
    }
}
