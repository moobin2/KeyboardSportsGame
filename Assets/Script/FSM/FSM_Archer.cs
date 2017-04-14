using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Archer : FSM_Base
{
    IEnumerator ArrowAim()
    {
        Debug.Log("Enter Crossbow Aim");
        _anim.CrossFade("Crossbow Aim", crossFadeTime);
        yield return null;

        while (currentState == UnitState.ArrowAim)
        {
            yield return null;
        }
    }

    IEnumerator ArrowShoot()
    {
        Debug.Log("Enter Crossbow Shoot Attack");
        float motionTime = 0.0f;
        _anim.CrossFade("Crossbow Shoot Attack", crossFadeTime);
        yield return null;

        while (currentState == UnitState.ArrowShoot)
        {
            motionTime += Time.deltaTime;
            if (motionTime > _animList["Crossbow Shoot Attack"])
            {
                SetState(UnitState.Idle);
            }
            yield return null;
        }
    }
}
