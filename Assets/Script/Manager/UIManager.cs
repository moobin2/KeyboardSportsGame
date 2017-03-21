using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ManagerTemplate<UIManager>
{
    // UIPanel 경로
    public const string uiPanelContainerPath = "GUI/Panel/";
    private Transform uiPanelContainer;

    private Dictionary<string, UIPanel_Base> uiPanelDic;    // UIPanel 딕셔너리
    private List<UIPanel_Base> activePanelList;             // 활성화된 패널 리스트

    protected override void Init()
    {
        base.Init();

        GameObject uiRoot = Instantiate(Resources.Load("GUI/UIRoot")) as GameObject;
        uiRoot.transform.SetParent(this.transform);
        uiRoot.transform.localPosition = Vector3.zero;
        uiRoot.transform.localScale = Vector3.one;

        uiPanelContainer = (new GameObject("PanelContainer")).transform;
        uiPanelContainer.SetParent(uiRoot.transform);
        uiPanelContainer.transform.localPosition = Vector3.zero;
        uiPanelContainer.transform.localScale = Vector3.one;

        if (uiPanelDic == null)
        {
            uiPanelDic = new Dictionary<string, UIPanel_Base>();
        }

        loadPanelsFromResources();
    }

    private void loadPanelsFromResources()
    {
        UIPanel_Base[] uiPanels = Resources.LoadAll<UIPanel_Base>(uiPanelContainerPath);

        for (int i = 0; i < uiPanels.Length; ++i)
        {
            UIPanel_Base panel = Instantiate(uiPanels[i]) as UIPanel_Base;

            panel.transform.SetParent(uiPanelContainer);
            panel.transform.localPosition = Vector3.zero;
            panel.transform.localScale = Vector3.one;

            uiPanelDic.Add(panel.GetType().ToString(), panel);
        }
    }

    public void hideAllPanel()
    {
        foreach (var pair in uiPanelDic)
        {
            pair.Value.hidePanel();
        }
    }

    public void initSceneUI(EGameScene scene)
    {
        switch (scene)
        {
            case EGameScene.TITLE:
                {
                    //UIPanel_TitleScene.instance.showPanel();
                }
                break;
            case EGameScene.MAIN:
                {

                }
                break;
        }
    }
}
