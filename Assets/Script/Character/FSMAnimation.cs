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
    public  eUnitState  CurrentState    = eUnitState.Idle;
    public  float       LerpTime        = 0.3f;
    public  float       MoveSpeed       = 5.0f;
    public  float       CrossFadeTime   = 0.2f;

    private Animation   Anim;
    private Dictionary<string, float> AnimNameList = new Dictionary<string, float>();

	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animation>();

        foreach (AnimationState AnimState in Anim)
        {
            AnimNameList.Add(AnimState.clip.name, AnimState.clip.length);
            Debug.Log(AnimState.clip.name.ToString() + ": length(" + AnimState.clip.length.ToString() + ")");
        }
	}
	
	public void SetState(eUnitState State)
    {
        // 현재 상태와 같다면 리턴
        if(CurrentState == State)
        {
            return;
        }
        Debug.Log("Change Motion");
        // 현재 상태를 바꿔준다
        CurrentState = State;

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

    IEnumerable Idle()
    {
        Debug.Log("Idle RunState");
        Anim.CrossFade("Idle", CrossFadeTime);
        yield return null;

        while(CurrentState == eUnitState.Idle)
        {
            yield return null;
        }
    }

    IEnumerable Run()
    {
        Debug.Log("Enter RunState");
        Anim.CrossFade("Run", CrossFadeTime);
        yield return null;

        while(CurrentState == eUnitState.Run)
        {
            yield return null;
        }
    }

    IEnumerable Attack()
    {
        Debug.Log("Enter AttackState");
        float Motiontime = 0.0f;
        Anim.CrossFade("Melee Right Attack 01", CrossFadeTime);
        yield return null;

        while (CurrentState == eUnitState.Attack)
        {
            Motiontime += Time.deltaTime;
            if(Motiontime > AnimNameList["Melee Right Attack 01"])
            {
                SetState(eUnitState.Idle);
            }
            yield return null;
        }
        Debug.Log("Exit AttackState");
    }

    IEnumerable Damaged()
    {
        float MotionTime = 0.0f;
        Anim.CrossFade("Take Damage", CrossFadeTime);
        yield return null;

        while(CurrentState == eUnitState.Damaged)
        {
            MotionTime += Time.deltaTime;
            if(MotionTime > AnimNameList["Damaged"])
            {
                SetState(eUnitState.Idle);
            }
            yield return null;
        }
    }
}
