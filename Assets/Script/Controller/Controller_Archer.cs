﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Archer : Controller_EnemyBase
{
    private Pool_Controller _arrowPool;

	// Use this for initialization
	void Awake()
    {
        base.Awake();
        _waitingTime = 3.0f;
        _type = EnermyType.Archer;

    }

    public void Init()
    {
        this.gameObject.SetActive(true);
        base.Init();
        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        if(_arrowPool == null)
        {
            _arrowPool = GameObject.FindGameObjectWithTag("ObjectPool").GetComponent<Pool_Controller>();
        }

        SetCrossbow();

        StartCoroutine("FindPlayer");
    }

    void SetCrossbow()
    {
        GameObject[] arrCrossbow = Resources.LoadAll<GameObject>("Weapon/Crossbow");

        GameObject crossbow = Instantiate(arrCrossbow[Random.Range(0, arrCrossbow.Length)]);

        crossbow.transform.parent = _leftHandPos.transform;
        crossbow.transform.localPosition = Vector3.zero;
        crossbow.transform.localRotation = Quaternion.Euler(-90, 0, 0);
        crossbow.transform.localScale = Vector3.one;
    }

    IEnumerator FindPlayer()
    {
       // _fsmAnim.SetState(UnitState.Idle);
        yield return new WaitForSeconds(_waitingTime);

      //  _fsmAnim.SetState(UnitState.ArrowAim);
        base.RotateToPlayer();
        _waitingTime = Random.Range(2.0f, 5.0f);
    }

    IEnumerator AttackToPlayer()
    {
      //  _fsmAnim.SetState(UnitState.ArrowShoot);
        yield return new WaitForSeconds(0.15f);
        _arrowPool.GetObjcet("Arrow").GetComponent<Pool_Arrow>().FireArrow(_leftHandPos.transform.position, _player.transform.position);

        StartCoroutine("FindPlayer");
    }
}
