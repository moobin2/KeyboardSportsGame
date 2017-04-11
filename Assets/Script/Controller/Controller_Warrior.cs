using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Warrior))]
public class Controller_Warrior : Controller_EnemyBase
{

    private FSM_Warrior _fsmAnim;

	// Use this for initialization
	void Start ()
    {
        base.Start();
        _attackTime = 2;

        _fsmAnim = GetComponent<FSM_Warrior>();
        _fsmAnim.SetState(UnitState.Idle);
	}

    void SetSword()
    {
        //GameObject[] arrSword = Resources.LoadAll<GameObject>("Weapon/Crossbow");

        //GameObject crossbow = Instantiate(arrCrossbow[Random.Range(0, arrCrossbow.Length)]);
        //crossbow.transform.parent = leftHandPos.transform;
        //crossbow.transform.localPosition = Vector3.zero;
        //crossbow.transform.localRotation = Quaternion.identity;
        //crossbow.transform.localScale = Vector3.one;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
