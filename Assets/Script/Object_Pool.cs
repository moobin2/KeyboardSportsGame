using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pool : MonoBehaviour
{
    public int          objectSize;

    private GameObject[] _objectPool;
    public GameObject[] ObjectPool
    {
        get { return _objectPool; }
    }

	// Use this for initialization
	void Start ()
    {
        GameObject[] arrArrow = Resources.LoadAll<GameObject>("Weapon/Arrow");

        this.gameObject.name = "ArrowPool";

		for(int i = 0; i < objectSize; ++i)
        {
            GameObject tempObject = Instantiate(arrArrow[Random.Range(0, arrArrow.Length)]);
            tempObject.name = "ArrowPool_" + i;
            tempObject.transform.SetParent(this.transform);
            tempObject.transform.localPosition = Vector3.zero;
            tempObject.transform.localScale = Vector3.one;
            tempObject.SetActive(false);
            tempObject.AddComponent<Controller_Arrow>();
        }
	}

}
