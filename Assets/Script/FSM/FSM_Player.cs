using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Player : FSM_Base
{
    //// 찌르기 모션
    //IEnumerator Attack1()
    //{
    //    //Debug.Log("Enter Attack1_State");
    //    float motionTime = 0.0f;
    //    _anim.CrossFade("Melee Right Attack 01", crossFadeTime);
    //    yield return null;

    //    while (currentState == UnitState.Attack1)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["Melee Right Attack 01"])
    //        {
    //            SetState(UnitState.Idle);
    //        }
    //        yield return null;
    //    }
    //}

    //IEnumerator JumpAttack()
    //{
    //    //Debug.Log("Enter JumpAttackState");
    //    _anim.CrossFade("Jump Right Attack 01", crossFadeTime);
    //    float motionTime = 0.0f;
    //    yield return null;

    //    while(currentState == UnitState.JumpAttack)
    //    {
    //        motionTime += Time.deltaTime;
    //        if (motionTime > _animList["Jump Right Attack 01"])
    //        {
    //            SetState(UnitState.Idle);
    //        }
    //        yield return null;
    //    }
    //}
}
