using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Player : FSM_Base
{
    protected override void Start()
    {
        base.Start();
    }

    protected IEnumerator Attack1()
    {
        Debug.Log("Enter Attack1_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 01", _crossFadeTime);
        yield return null;

        while (_currentState == UnitState.Attack1)
        {
            motionTime += Time.deltaTime;
            Debug.Log(motionTime);
            if (motionTime > _animList["Melee Right Attack 01"])
            {
                Debug.Log("idle로바꿈");
                base.SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    IEnumerator Attack2()
    {
        Debug.Log("Enter Attack2_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 02", _crossFadeTime);
        yield return null;

        while (_currentState == UnitState.Attack2)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Melee Right Attack 02"])
            {
                base.SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    protected virtual IEnumerator Attack3()
    {
        Debug.Log("Enter Attack3_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 03", _crossFadeTime);
        yield return null;

        while (_currentState == UnitState.Attack3)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Melee Right Attack 03"])
            {
                base.SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    protected virtual IEnumerator Dameged()
    {
        yield return null;
    }
}
