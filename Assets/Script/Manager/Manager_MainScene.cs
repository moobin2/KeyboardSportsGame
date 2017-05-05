using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_MainScene : MonoBehaviour
{
    public GameObject objectPool;
    public GameObject[] Castles;

    private int time;
    private Pool_Controller _objPoolCtrl;
    private List<Controller_Castle> _castlesCtrl;

    void Start()
    {
        this.gameObject.name = "[Manager]MainScene";

        _objPoolCtrl = objectPool.GetComponent<Pool_Controller>();

        MainSceneInit();

        _castlesCtrl = new List<Controller_Castle>();
        for(int i = 0; i < Castles.Length; ++i)
        {
            _castlesCtrl.Add(Castles[i].GetComponent<Controller_Castle>());
        }


        StartCoroutine("ResoponEnermy");
    }
	
	// Update is called once per frame
	void Update ()
    {


    }
    
    IEnumerator IncreaseSecond()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);

            time += 1;

            UIPanel_Time.instance.SetTime(time);
        }
    }


    IEnumerator ResoponEnermy()
    {
        int count = 0;

        while (true)
        {
            yield return new WaitForSeconds(5.0f);

            ArcherRespon();
            count++;

            if (count == 4)
                break;
        }

    }

    void ArcherRespon()
    {
        while (true)
        {
            int castleNum = Random.Range(0, Castles.Length);
            if (_castlesCtrl[castleNum].IsArcher == false)
            {
                _castlesCtrl[castleNum].SetArcher();
                break;
            }
        }
    }

    public void MainSceneInit()
    {
        Manager_Game.Player.GetComponent<Controller_Player>().Init();
        _objPoolCtrl.AddObjectPool("Arrow", "Weapon/Arrow", 10);
        _objPoolCtrl.AddObjectPool("Archer", "Character/Model/Archer", 4);
    }
}
