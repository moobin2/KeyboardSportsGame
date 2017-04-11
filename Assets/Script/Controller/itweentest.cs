using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itweentest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
        {
            iTween.RotateAdd(gameObject, new Vector3(0, 0, 90), 0.5f);
        }
	}
}
