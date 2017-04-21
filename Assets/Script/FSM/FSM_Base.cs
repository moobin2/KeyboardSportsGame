using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BASESTATE
{
    Normal, TwoHand, Flying
}

public enum MOTIONSTATE
{
    Idle, 
    Run, 
    Attack1, 
    Attack2, 
    Attack3, 
    JumpAttack, 
    SpinAttack,	
    CrossbowAim, 
    CrossbowShoot, 
    Damaged, 
    Die		
}

[RequireComponent(typeof(Animator))]
public class FSM_Base : MonoBehaviour
{
    public BASESTATE currentBaseState;
    public BASESTATE CurrentBaseState { get { return currentBaseState; } }
    public MOTIONSTATE currentMotionState;
    public MOTIONSTATE CurrentMotionState { get { return currentMotionState; } }

    //public      float crossFadeTime = 0.2f;
    //protected   Dictionary<string, float> _animList;
    protected   Animator _anim;
    protected   bool _isChangeState;

    // Use this for initialization

    void Awake()
    {
        _anim = GetComponent<Animator>();
        _isChangeState = false;

    }

    public void Init()
    {
        StartCoroutine("FsmMain");
    }

    public void SetState(BASESTATE baseState, MOTIONSTATE motionState)
    {
        //Debug.Log("Chage to " + state.ToString());
        currentBaseState = baseState;
        currentMotionState = motionState;
        _isChangeState = true;
    }

    IEnumerator FsmMain()
    {
        while (true)
        {
            if (_isChangeState == true)
            {
                _isChangeState = false;
                _anim.SetInteger("BaseState", (int)currentBaseState);
                _anim.SetInteger("MotionState", (int)currentMotionState);
                StartCoroutine("WaitForAnimation", _anim.GetCurrentAnimatorStateInfo(0).length);
                yield return null;
            }
            else
            {
                yield return null;
            }
        }
    }

    IEnumerator WaitForAnimation(float time)
    {
        //yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.1f);


        if (currentMotionState == MOTIONSTATE.Idle || currentMotionState == MOTIONSTATE.Run)
        {
            yield return null;
        }
        else
        {
            float animLength = _anim.GetCurrentAnimatorStateInfo(0).length;
            Debug.Log(time);
            yield return new WaitForSeconds(time - 0.1f);
            SetState(currentBaseState, MOTIONSTATE.Idle);
        }
    }

    //IEnumerator WaitForAnimation()
    //{
    //    //while (true == animator.GetCurrentAnimatorStateInfo(0).IsName(name)) {
    //    while (false == _anim.IsInTransition(0))
    //    {
    //        yield return null;
    //    }
    //    Debug.Log("모션끝");
    //    currentMotionState = (int)MOTIONSTATE.Idle;
    //}

    //protected IEnumerator Idle()
    //{
    //    //Debug.Log("Enter IdleState");
    //    _anim.CrossFade("Idle", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.Idle)
    //    {
    //        yield return null;
    //    }
    //    //Debug.Log("Exit IdleState");
    //}

    //protected IEnumerator TH_Idle()
    //{
    //    _anim.CrossFade("TH Sword Idle", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.TH_Idle)
    //    {
    //        yield return null;
    //    }
    //}

    //protected IEnumerator Run()
    //{
    //    //Debug.Log("Enter RunState");
    //    _anim.CrossFade("Run", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.Run)
    //    {
    //        yield return null;
    //    }
    //    //Debug.Log("Exit RunState");
    //}

    //protected IEnumerator TH_Run()
    //{
    //    //Debug.Log("Enter RunState");
    //    _anim.CrossFade("TH Sword Run Without Root Motion", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.TH_Run)
    //    {
    //        yield return null;
    //    }
    //    //Debug.Log("Exit RunState");
    //}

    //protected IEnumerator Attack2()
    //{
    //    //Debug.Log("Enter Attack2_State");
    //    float motionTime = 0.0f;
    //    _anim.CrossFade("Melee Right Attack 02", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.Attack2)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["Melee Right Attack 02"])
    //        {
    //            SetState(UnitState.Idle);
    //        }
    //        yield return null;
    //    }
    //}

    //protected IEnumerator Attack3()
    //{
    //    //Debug.Log("Enter Attack3_State");
    //    float motionTime = 0.0f;
    //    _anim.CrossFade("Melee Right Attack 03", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.Attack3)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["Melee Right Attack 03"])
    //        {
    //            SetState(UnitState.Idle);
    //        }
    //        yield return null;
    //    }
    //}

    //protected IEnumerator TH_Attack1()
    //{
    //    //Debug.Log("Enter Attack2_State");
    //    float motionTime = 0.0f;
    //    _anim.CrossFade("TH Sword Melee Attack 01", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.TH_Attack1)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["TH Sword Melee Attack 01"])
    //        {
    //            SetState(UnitState.TH_Idle);
    //        }
    //        yield return null;
    //    }
    //}

    //protected IEnumerator TH_Attack2()
    //{
    //    //Debug.Log("Enter Attack3_State");
    //    float motionTime = 0.0f;
    //    _anim.CrossFade("TH Sword Melee Attack 02", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.TH_Attack2)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["TH Sword Melee Attack 02"])
    //        {
    //            SetState(UnitState.TH_Idle);
    //        }
    //        yield return null;
    //    }
    //}

    //protected IEnumerator Damaged()
    //{
    //    yield return null;
    //}

    //protected IEnumerator Die()
    //{
    //    yield return null;
    //}
}
