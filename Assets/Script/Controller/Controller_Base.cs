using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FSM_Base))]
public class Controller_Base : MonoBehaviour
{
    protected BASESTATE currentBaseMotion;
    protected int currentHp;
    protected int maxHp;
    protected int damage;

    protected FSM_Base _fsmAnim;

	// Use this for initialization
	protected void Awake()
    {
        _fsmAnim = GetComponent<FSM_Base>();
	}

    protected void Init()
    {
        _fsmAnim.Init();
    }
            

    protected void SetMotionState(MOTIONSTATE motion)
    {
        _fsmAnim.SetState(currentBaseMotion, motion);
    }

}
