﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Archer))]
public class Controller_Archer : Controller_EnemyBase
{
    public GameObject objectContainer;

    private FSM_Archer      _fsmAnim;
    private Pool_Controller _arrowPool;

	// Use this for initialization
	void Start ()
    {
        base.Start();
        _waitingTime = 3.0f;
        _fsmAnim = GetComponent<FSM_Archer>();
        //_fsmAnim.SetState(UnitState.Idle);
        _type = EnermyType.Archer;

        _arrowPool = objectContainer.GetComponent<Pool_Controller>();

        SetCrossbow();

        this.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);

        StartCoroutine("FindPlayer");
    }

    void SetCrossbow()
    {
        GameObject[] arrCrossbow = Resources.LoadAll<GameObject>("Weapon/Crossbow");

        GameObject crossbow = Instantiate(arrCrossbow[Random.Range(0, arrCrossbow.Length)]);
        crossbow.transform.parent = leftHandPos.transform;
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
        _arrowPool.GetObjcet("Arrow").GetComponent<Pool_Arrow>().FireArrow(leftHandPos.transform.position, _player.transform.position);

        StartCoroutine("FindPlayer");
    }
}
