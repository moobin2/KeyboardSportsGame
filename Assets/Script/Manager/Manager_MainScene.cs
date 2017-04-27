using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_MainScene : MonoBehaviour
{
    public GameObject objectPool;

    private Pool_Controller objPoolCtrl;

    void Start()
    {
        this.gameObject.name = "[Manager]MainScene";

        objPoolCtrl = objectPool.GetComponent<Pool_Controller>();
        MainSceneInit();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void MainSceneInit()
    {
        Manager_Game.Player.GetComponent<Controller_Player>().Init();
        objPoolCtrl.AddObjectPool("Arrow", "Weapon/Arrow", 10);
        objPoolCtrl.AddObjectPool("Archer", "Character/Model", 4);
    }
}
