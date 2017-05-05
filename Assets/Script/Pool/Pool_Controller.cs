using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Controller : MonoBehaviour
{
    private Dictionary<string, List<GameObject>> _objPoolDic;
    public Dictionary<string, List<GameObject>> ObjectPool
    {
        get { return _objPoolDic; }
    }

    // Use this for initialization
    void Awake()
    {
        _objPoolDic = new Dictionary<string, List<GameObject>>();

        this.gameObject.name = "[Container]ObjectPool";
    }

    public void AddObjectPool(string objectName, string objectPath, int objectSize)
    {
        GameObject objectContainer = new GameObject();
        objectContainer.name = objectName;
        objectContainer.transform.SetParent(this.transform);

        GameObject[] arrObj = Resources.LoadAll<GameObject>(objectPath);
        List<GameObject> objPoolList = new List<GameObject>();

        for (int i = 0; i < objectSize; ++i)
        {
            GameObject tempObject = Instantiate(arrObj[Random.Range(0, arrObj.Length)]);
            tempObject.name = objectName + "_" + i;

            if(objectName == "Arrow")
            {
                tempObject.AddComponent<Pool_Arrow>();
            }

            tempObject.transform.SetParent(objectContainer.transform);
            tempObject.transform.localPosition = Vector3.zero;
            tempObject.transform.localScale = Vector3.one;
            tempObject.SetActive(false);
            objPoolList.Add(tempObject);
        }
        _objPoolDic.Add(objectName, objPoolList);
    }

    public GameObject GetObjcet(string objectName)
    {
        int objectsize = _objPoolDic[objectName].Count;
        for (int i = 0; i < objectsize; ++i)
        {
            if (_objPoolDic[objectName][i].activeInHierarchy)
            {
                continue;
            }
            else
            {
                return _objPoolDic[objectName][i];
            }
        }
        return null;
    }
}
