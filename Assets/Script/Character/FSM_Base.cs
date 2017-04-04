using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitState
{
    Idle, Run, Dameged, Die,        // 공통모션
    Attack1, Attack2, Attack3       // 플레이어
}

[RequireComponent(typeof(Animation))]
public class FSM_Base : MonoBehaviour
{
    public      UnitState _currentState;
    public      float _crossFadeTime = 0.2f;
    protected   Animation _anim;
    protected   Dictionary<string, float> _animList;
    protected   bool _isChangeState;

    // Use this for initialization

    protected virtual void Start()
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

    public virtual void SetState(UnitState state)
    {
        Debug.Log("Chage to " + state.ToString());
        _currentState = state;
        _isChangeState = true;
    }

    IEnumerator FsmMain()
    {
        while (true)
        {
            if (_isChangeState == true)
            {
                Debug.Log("상태바꾼다~");
                _isChangeState = false;
                StartCoroutine(_currentState.ToString());
                Debug.Log(_currentState.ToString());
                yield return null; 
            }
            else
            {
                yield return null;
            }
        }
    }

    protected virtual IEnumerator Idle()
    {
        Debug.Log("Enter IdleState");
        _anim.CrossFade("Idle", _crossFadeTime);
        yield return null;

        while (_currentState == UnitState.Idle)
        {
            yield return null;
        }
        Debug.Log("Exit IdleState");
    }

    protected virtual IEnumerator Run()
    {
        Debug.Log("Enter RunState");
        _anim.CrossFade("Run", _crossFadeTime);
        yield return null;

        while (_currentState == UnitState.Run)
        {
            yield return null;
        }
        Debug.Log("Exit RunState");
    }

    protected virtual IEnumerator Damaged()
    {
        yield return null;
    }

    protected virtual IEnumerator Die()
    {
        yield return null;
    }
}
