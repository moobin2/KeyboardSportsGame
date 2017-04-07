using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum eUnitState
{
    Idle, Attack, Run, Damaged
}

[RequireComponent(typeof(Animation))]
public class FSMAnimation : MonoBehaviour
{
    public  eUnitState  currentState    = eUnitState.Idle;
    public  float       lerpTime        = 0.3f;
    public  float       moveSpeed       = 5.0f;
    public  float       crossFadeTime   = 0.2f;

    private Animation   _anim;
    private Dictionary<string, float> _animNameList = new Dictionary<string, float>();

	// Use this for initialization
	void Start ()
    {
        _anim = GetComponent<Animation>();

        foreach (AnimationState AnimState in _anim)
        {
            _animNameList.Add(AnimState.clip.name, AnimState.clip.length);
            Debug.Log(AnimState.clip.name.ToString() + ": length(" + AnimState.clip.length.ToString() + ")");
        }
	}

    public void AttackMotion()
    {
        Debug.Log("Enter AttackState");
        _anim.CrossFade("Melee Right Attack 01", crossFadeTime);
        currentState = eUnitState.Attack;
        Debug.Log("Exit AttackState");
    }
	
	public void SetState(eUnitState State)
    {
        // 현재 상태와 같다면 리턴
        if(currentState == State)
        {
            return;
        }
        Debug.Log("Change Motion");
        // 현재 상태를 바꿔준다
        currentState = State;

        // 모션을 바꿔준다.
        switch (State)
        {
            case eUnitState.Idle:
                StartCoroutine("Idle");
                Debug.Log("StartCoroutine Idle");
                break;
            case eUnitState.Run:
                StartCoroutine("Run");
                Debug.Log("StartCoroutine Run");
                break;
            case eUnitState.Attack:
                StartCoroutine("Attack");
                Debug.Log("StartCoroutine Attack");
                break;
            case eUnitState.Damaged:
                StartCoroutine("Damaged");
                Debug.Log("StartCoroutine Damaged");
                break;
            default:
                break;
        }
    }

    IEnumerator Idle()
    {
        Debug.Log("Idle RunState");
        _anim.CrossFade("Idle", crossFadeTime);
        yield return null;

        while(currentState == eUnitState.Idle)
        {
            yield return null;
        }
    }

    IEnumerator Run()
    {
        Debug.Log("Enter RunState");
        _anim.CrossFade("Run", crossFadeTime);
        yield return null;

        while(currentState == eUnitState.Run)
        {
            yield return null;
        }
    }

    IEnumerator Attack()
    {
        Debug.Log("Enter AttackState");
        float Motiontime = 0.0f;
        _anim.CrossFade("Melee Right Attack 01", crossFadeTime);
        yield return null;

        while (currentState == eUnitState.Attack)
        {
            Motiontime += Time.deltaTime;
            if(Motiontime > _animNameList["Melee Right Attack 01"])
            {
                SetState(eUnitState.Idle);
            }
            yield return null;
        }
        Debug.Log("Exit AttackState");
    }

    IEnumerator Damaged()
    {
        float MotionTime = 0.0f;
        _anim.CrossFade("Take Damage", crossFadeTime);
        yield return null;

        while(currentState == eUnitState.Damaged)
        {
            MotionTime += Time.deltaTime;
            if(MotionTime > _animNameList["Damaged"])
            {
                SetState(eUnitState.Idle);
            }
            yield return null;
        }
    }
}
