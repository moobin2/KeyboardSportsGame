using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class FSM_Base : MonoBehaviour
{
    protected enum UnitState
    {
        Idle, Run, Death
    }

    private UnitState                   _currentState;
    private Animation                   _anim;
    private Dictionary<string, float>   _animList;
    private bool                        _isChangeState;


    // Use this for initialization

    protected virtual void Start ()
    {
        _anim = GetComponent<Animation>();
        _isChangeState = false;

        foreach (AnimationState AnimState in _anim)
        {
            _animList.Add(AnimState.clip.name, AnimState.clip.length);
        }

        StartCoroutine("FsmMain");
    }

    IEnumerable FsmMain()
    {
        while(true)
        {
            if(_isChangeState == true)
            {
                _isChangeState = false;
                yield return StartCoroutine(_currentState.ToString());
            }
        }
    }

    protected virtual IEnumerator Idle()
    {
        yield return null;
    }

    protected virtual IEnumerator Run()
    {
        yield return null;
    }

    protected virtual IEnumerator Death()
    {
        yield return null;
    }
}
