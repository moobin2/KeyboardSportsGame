using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Controller_Castle : MonoBehaviour
{
    private Animator    _anim;
    private bool        _bIsOpen;
    // Use this for initialization
    void Start ()
    {
        _bIsOpen = false;
        _anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
