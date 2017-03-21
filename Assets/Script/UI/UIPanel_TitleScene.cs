using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_TitleScene : UIPanel_Template<UIPanel_TitleScene>
{
    public void OnClickStart()
    {
        GameSceneManager.Instance.ChangeScene(EGameScene.MAIN);
    }
}
