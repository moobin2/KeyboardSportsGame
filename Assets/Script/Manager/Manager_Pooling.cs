using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

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
        //sb.AppendFormat("[{0}] {1}", index, name.ToString());

        for(int i = 0; i < size; ++i)
        {
            GameObject obj = Instantiate(addObject);
            obj.name = addObjectName + size;
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;
            obj.transform.SetParent(ObjectContainer.transform);
        }

    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
