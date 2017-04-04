using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Player : FSM_Base
{
    protected enum UnitState
    {
        Idle, Run, Attack1, Attack2, Attack3, Dameged, Death
    }
    

	//// Use this for initialization
	//void Start ()
    //{
	//   
	//}
	
	// Update is called once per frame
	void Update () {
		
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

    protected virtual IEnumerator Attack1()
    {
        yield return null;
    }

    protected virtual IEnumerator Attack2()
    {
        yield return null;
    }

    protected virtual IEnumerator Attack3()
    {
        yield return null;
    }

    protected virtual IEnumerator Dameged()
    {
        yield return null;
    }
}
