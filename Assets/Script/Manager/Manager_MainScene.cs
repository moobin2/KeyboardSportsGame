using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_MainScene : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.gameObject.name = "[Manager]MainScene";
        MainSceneInit();

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MainSceneInit()
    {
        Manager_Game.Player.GetComponent<Controller_Player>().Init();
    }
}
