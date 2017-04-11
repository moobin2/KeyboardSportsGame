using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Player : FSM_Base
{
    IEnumerator Attack1()
    {
        //Debug.Log("Enter Attack1_State");
        float motionTime = 0.0f;
        _anim.CrossFade("Melee Right Attack 01", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Attack1)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Melee Right Attack 01"])
            {
                SetState(UnitState.Idle);
            }
            yield return null;
        }
    }

    IEnumerator Attack2()
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

    IEnumerator Attack3()
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

    IEnumerator JumpAttack()
    {
        //Debug.Log("Enter JumpAttackState");
        _anim.CrossFade("Jump Right Attack 01", crossFadeTime);
        float motionTime = 0.0f;
        yield return null;

        while(currentState == UnitState.JumpAttack)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Jump Right Attack 01"])
            {
                SetState(UnitState.Idle);
            }
            yield return null;
        }
    }
}
