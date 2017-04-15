using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum SwordType
{
    OneHand, TwoHand
}

[RequireComponent(typeof(FSM_Warrior))]
public class Controller_Warrior : Controller_EnemyBase
{
    private FSM_Warrior _fsmAnim;
    private SwordType _swordType;

	// Use this for initialization
	void Start ()
    {
        base.Start();

        _swordType = (SwordType)Random.Range(1, 2);
        _fsmAnim = GetComponent<FSM_Warrior>();
        _fsmAnim.SetState(UnitState.Idle);
        _type = EnermyType.Warrior;
        _waitingTime = 1.0f;

        SetSword();

        StartCoroutine("FindPlayer");
    }

    void SetSword()
    {
        GameObject[] arrSword;

        if (_swordType == SwordType.OneHand)
            arrSword = Resources.LoadAll<GameObject>("Weapon/Sword/One Handed");
        else
            arrSword = Resources.LoadAll<GameObject>("Weapon/Sword/Two Handed");

        for(int i = 0; i < arrSword.Length; ++i)
        {
            Debug.Log(arrSword[i].ToString());
        }

        GameObject sword = Instantiate(arrSword[Random.Range(0, arrSword.Length)]);
        sword.transform.parent = rightHandPos.transform;
        sword.transform.localPosition = Vector3.zero;
        sword.transform.localRotation = Quaternion.identity;
        sword.transform.localScale = Vector3.one;
    }

    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(_waitingTime);

        if (_swordType == SwordType.OneHand)
            _fsmAnim.SetState(UnitState.Run);
        else
            _fsmAnim.SetState(UnitState.TH_Run);

        base.RotateToPlayer();
    }

    IEnumerator AttackToPlayer()
    {
        yield return new WaitForSeconds(1.0f);
        int motionNumber = Random.Range(0, 2);
       
        switch(motionNumber)
        {
            case 0:
                if(_swordType == SwordType.OneHand) _fsmAnim.SetState(UnitState.Attack2);
                else _fsmAnim.SetState(UnitState.TH_Attack1);
                break;
            case 1:
                if (_swordType == SwordType.OneHand) _fsmAnim.SetState(UnitState.Attack3);
                else _fsmAnim.SetState(UnitState.TH_Attack2);
                break;
        }

        StartCoroutine("FindPlayer");
    }
}
