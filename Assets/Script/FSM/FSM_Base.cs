using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle, Run, Dameged, Die,                                // 공통모션
    Attack1, Attack2, Attack3, JumpAttack, SpinAttack,      // 플레이어
    FireArrow
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
        Debug.Log("Base Start");
        _anim = GetComponent<Animation>();
        _isChangeState = false;

        _animList = new Dictionary<string, float>();

        foreach (AnimationState AnimState in _anim)
        {
            _animList.Add(AnimState.clip.name, AnimState.clip.length);
            Debug.Log(AnimState.clip.name.ToString() + ": length(" + AnimState.clip.length.ToString() + ")");
        }

        StartCoroutine("FsmMain");
    }

    public void SetState(UnitState state)
    {
        Debug.Log("Chage to " + state.ToString());
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
        Debug.Log("Enter IdleState");
        _anim.CrossFade("Idle", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Idle)
        {
            yield return null;
        }
        Debug.Log("Exit IdleState");
    }

    protected IEnumerator Run()
    {
        Debug.Log("Enter RunState");
        _anim.CrossFade("Run", crossFadeTime);
        yield return null;

        while (currentState == UnitState.Run)
        {
            yield return null;
        }
        Debug.Log("Exit RunState");
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
