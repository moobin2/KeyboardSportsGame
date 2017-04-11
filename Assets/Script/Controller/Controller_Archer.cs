using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Archer))]
public class Controller_Archer : Controller_EnemyBase
{
    Transform _arrowFirePos;
    private int             _arrowSize;
    private FSM_Archer      _fsmAnim;
    private GameObject[]    _arrowPool;

	// Use this for initialization
	void Start ()
    {
        base.Start();
        _attackTime = 3.0f;
        _arrowSize = 10;
        _fsmAnim = GetComponent<FSM_Archer>();
        _fsmAnim.SetState(UnitState.Idle);

        SetCrossbow();
        MakeArrowPool();

        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    void SetCrossbow()
    {
        GameObject[] arrCrossbow = Resources.LoadAll<GameObject>("Weapon/Crossbow");

        GameObject crossbow = Instantiate(arrCrossbow[Random.Range(0, arrCrossbow.Length)]);
        crossbow.transform.parent = leftHandPos.transform;
        crossbow.transform.localPosition = Vector3.zero;
        crossbow.transform.localRotation = Quaternion.identity;
        crossbow.transform.localScale = Vector3.one;
    }

    void MakeArrowPool()
    {
        GameObject[] arrArrow = Resources.LoadAll<GameObject>("Weapon/Arrow");

        int arrowNunber = Random.Range(0, arrArrow.Length);

        for (int i = 0; i < _arrowSize; ++i)
        {
            GameObject crossbow = Instantiate(arrArrow[arrowNunber]);
            crossbow.transform.localPosition = Vector3.zero;
            crossbow.transform.localRotation = Quaternion.identity;
            crossbow.transform.localScale = Vector3.one;
            crossbow.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(_attackTime);

        RotateToPlayer();
    }

    //void RotateToPlayer()
    //{
    //    // 플레이어 위치에 따른 각도 계산
    //    Vector3 playerDirection = (_player.transform.position - transform.position).normalized;
    //    float dot = Vector3.Dot(playerDirection, Vector3.forward);
    //    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

    //    // 외적을 이용해 -180~180의 각도로 계산
    //    Vector3 temp = Vector3.Cross(Vector3.forward, playerDirection).normalized;
    //    angle = (temp.y > 0) ? angle : -angle;

    //    iTween.RotateTo(gameObject, iTween.Hash("rotation", new Vector3(0, angle, 0), "easeType", "Linear", "time", 0.3f, "oncomplete", "FireArrow"));
    //}

    void AttackToPlayer()
    {
        for(int i = 0; i < _arrowSize; ++i)
        {
            if(_arrowPool[i].activeInHierarchy == true)
            {
                continue;
            }
            else
            {
                _arrowPool[i].GetComponent<Controller_Arrow>().FireArrow(_arrowFirePos.position, _player.transform.position);
                break;
            }
        }
    }
}
