using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	void Start ()
    {
        this.gameObject.name = "[Manager]GamaManager";      // 해당 오브젝트이름 바꾸기
        DontDestroyOnLoad(this);                            // 매니저이기때문에 계속 살려두어야한다.

        ManagerInit();
    }

    void ManagerInit()
    {
        UIManager.Create();                                 // UI매니저, 씬매니저 생성
        GameSceneManager.Create();
    }
}
