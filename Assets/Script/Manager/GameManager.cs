using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        this.gameObject.name = "[Manager]GamaManager";
        DontDestroyOnLoad(this);

        ManagerInit();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void ManagerInit()
    {
        UIManager.Create();
        GameSceneManager.Create();
    }
}
