using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Template<T> : UIPanel_Base where T : UIPanel_Template<T>
{
    private static T _instance = null;

    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("<color=maroon> _instance == null </color>");
            }
            return _instance;
        }
    }

    void Awake()
    {
        _instance = this as T;
        this.gameObject.name = this.GetType().ToString();
        this.gameObject.SetActive(false);

        init();
    }
}