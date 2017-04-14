using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle, Run, Dameged, Die,                                // 공통모션
    Attack1, Attack2, Attack3, JumpAttack, SpinAttack,      // 플레이어
    ArrowAim, ArrowShoot,                                   // 궁수
    TH_Idle, TH_Run, TH_Attack1, TH_Attack2,

}

[RequireComponent(typeof(Animation))]
public class FSM_Base : MonoBehaviour
{
    public      UnitState currentState;
    public      float crossFadeTime = 0.2f;
    protected   Animation _anim;
    protected   Dictionary<string, float> _animList;
    protected   bool _isChangeState;

    // Use this for initialization

    protected void Start()
    {
        //Debug.Log("Base Start");
        _anim = GetComponent<Animation>();
        _isChangeState = false;

        _animList = new Dictionary<string, float>();

        foreach (AnimationState AnimState in _anim)
        {
            _animList.Add(AnimState.clip.name, AnimState.clip.length);
            //Debug.Log(AnimState.clip.name.ToString() + ": length(" + AnimState.clip.length.ToString() + ")");
        }

        StartCoroutine("FsmMain");
    }

    public void SetState(UnitState state)
    {
        //Debug.Log("Chage to " + state.ToString());
        currentState = state;
        _isChangeState = true;
    }

    IEnumerator FsmMain()
    {
        while (true)
        {
            if (_isChangeState == true)
            {
                _isChangeState = false;
                StartCoroutine(currentState.ToString());
                Debug.Log(currentState.ToString());
                yield return null; 
            }
            else
            {
                yield return null;
            }
        }
    }

    protected IEnumerator Idle()
    {
        //Debug.Log("Enter IdleState");
        _anim.CrossFade("Idle", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Idle)
        {
            yield return null;
        }
        //Debug.Log("Exit IdleState");
    }

    protected IEnumerator TH_Idle()
    {
        _anim.CrossFade("TH Sword Idle", crossFadeTime);
        yield return null;

        while (currentState == UnitState.TH_Idle)
        {
            yield return null;
        }
    }

    protected IEnumerator Run()
    {
        //Debug.Log("Enter RunState");
        _anim.CrossFade("Run", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Run)
        {
            yield return null;
        }
        //Debug.Log("Exit RunState");
    }

    protected IEnumerator TH_Run()
    {
        //Debug.Log("Enter RunState");
        _anim.CrossFade("TH Sword Run With Root Motion", crossFadeTime);
        yield return null;

        while (currentState == UnitState.TH_Run)
        {
            yield return null;
        }
        //Debug.Log("Exit RunState");
    }

    protected IEnumerator Attack2()
    {
        //Debug.Log("Enter Attack2_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 02", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Attack2)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Melee Right Attack 02"])
            {
                SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    protected IEnumerator Attack3()
    {
        //Debug.Log("Enter Attack3_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 03", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Attack3)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Melee Right Attack 03"])
            {
                SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    protected IEnumerator TH_Attack1()
    {
        //Debug.Log("Enter Attack2_State");
        float motionTime = 0.0f;
        _anim.CrossFade("TH Sword Melee Attack 01", crossFadeTime);
        yield return null;

        while (currentState == UnitState.TH_Attack1)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["TH Sword Melee Attack 01"])
            {
                SetState(UnitState.TH_Idle);
            }
            yield return null;
        }
    }

    protected IEnumerator TH_Attack2()
    {
        //Debug.Log("Enter Attack3_State");
        float motionTime = 0.0f;
        _anim.CrossFade("TH Sword Melee Attack 02", crossFadeTime);
        yield return null;

        while (currentState == UnitState.TH_Attack2)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["TH Sword Melee Attack 02"])
            {
                SetState(UnitState.TH_Idle);
            }
            yield return null;
        }
    }

    protected IEnumerator Damaged()
    {
        yield return null;
    }

    protected IEnumerator Die()
    {
        yield return null;
    }
}
