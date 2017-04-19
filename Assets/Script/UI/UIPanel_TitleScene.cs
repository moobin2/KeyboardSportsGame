using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_TitleScene : UIPanel_Template<UIPanel_TitleScene>
{
    public void OnClickStart()
    {
        Manager_GameScene.Instance.ChangeScene(EGameScene.MAIN);
    }

    public void OnClickStartToTestSceneM()
    {
        Manager_GameScene.Instance.ChangeScene(EGameScene.TEST_M);
    }
}
