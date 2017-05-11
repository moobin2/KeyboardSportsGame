using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_UI : Manager_Template<Manager_UI>
{
    public const string uiPanelContainerPath = "GUI/Panel/";
    private Transform _uiPanelContainer;

    private Dictionary<string, UIPanel_Base> uiPanelDic;    // UIPanel 딕셔너리
    private List<UIPanel_Base> activePanelList;             // 활성화된 패널 리스트
    public List<UIPanel_Base> ActivePanelList { get { return activePanelList; } }

    protected override void Init()
    {
        base.Init();

        GameObject uiRoot = Instantiate(Resources.Load("GUI/UIRoot")) as GameObject;
        uiRoot.transform.SetParent(this.transform);
        uiRoot.transform.localPosition = Vector3.zero;
        uiRoot.transform.localScale = Vector3.one;

        _uiPanelContainer = (new GameObject("PanelContainer")).transform;
        _uiPanelContainer.SetParent(uiRoot.transform);
        _uiPanelContainer.transform.localPosition = Vector3.zero;
        _uiPanelContainer.transform.localScale = Vector3.one;

        if (uiPanelDic == null)
        {
            uiPanelDic = new Dictionary<string, UIPanel_Base>();
        }

        LoadPanelsFromResources();
    }

    private void LoadPanelsFromResources()
    {
        UIPanel_Base[] uiPanels = Resources.LoadAll<UIPanel_Base>(uiPanelContainerPath);

        for (int i = 0; i < uiPanels.Length; ++i)
        {
            UIPanel_Base panel = Instantiate(uiPanels[i]) as UIPanel_Base;

            panel.transform.SetParent(_uiPanelContainer);
            panel.transform.localPosition = Vector3.zero;
            panel.transform.localScale = Vector3.one;

            uiPanelDic.Add(panel.GetType().ToString(), panel);
        }
    }

    public void HideAllPanel()
    {
        foreach (var pair in uiPanelDic)
        {
            pair.Value.hidePanel();
        }
    }

    public void InitSceneUI(EGameScene scene)
    {
        switch (scene)
        {
            case EGameScene.TITLE:
                {
                    UIPanel_TitleScene.instance.showPanel();
                }
                break;
            case EGameScene.MAIN:
                {

                }
                break;
            case EGameScene.TEST_M:
                {
                    UIPanel_PlayerGauge.instance.showPanel();
                    UIPanel_Time.instance.showPanel();
                    UIPanel_Coin.instance.showPanel();
                }
                break;
        }
    }
}
