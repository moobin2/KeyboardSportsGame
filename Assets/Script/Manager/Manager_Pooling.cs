using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager_Pooling : Manager_Template<Manager_Pooling>
{
    protected override void Init()
    {
        base.Init();
    }


    public void AddObjectPool(string addObjectName, GameObject addObject, int size)
    {
        GameObject ObjectContainer = new GameObject();
        ObjectContainer.transform.SetParent(this.transform);
        ObjectContainer.name = addObjectName + "Root";
        //stringbuilder


    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
