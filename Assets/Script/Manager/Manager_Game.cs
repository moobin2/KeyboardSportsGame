using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Game : MonoBehaviour
{
    static GameObject _player;
    static public GameObject Player { get { return _player; } } 
        
    void Start()
    {

        this.gameObject.name = "[Manager]GamaManager";      // 해당 오브젝트이름 바꾸기
        DontDestroyOnLoad(this);                            // 매니저이기때문에 계속 살려두어야한다.

        ManagerInit();
        LoadPlayer();
    }

    void LoadPlayer()
    {
        GameObject model = Resources.Load("Character/Model/Male White Naked") as GameObject;
        _player = Instantiate(model);
        _player.AddComponent<Controller_Player>();
		_player.AddComponent<Item_Inventory>();
        _player.transform.position = Vector3.zero;
        _player.transform.localScale = Vector3.one;
        _player.SetActive(false);
    }

    void ManagerInit()
    {
        Manager_UI.Create();                                 // UI매니저, 씬매니저 생성
        Manager_GameScene.Create();
        Manager_Effect.Create();
		Manager_Item.Create();
    }
}
