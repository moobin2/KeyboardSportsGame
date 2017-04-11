using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Archer : FSM_Base
{
    IEnumerator FireArrow()
    {
        Debug.Log("Enter Attack1_State");
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
}
