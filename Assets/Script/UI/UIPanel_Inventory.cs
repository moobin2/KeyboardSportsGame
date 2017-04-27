using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Inventory : UIPanel_Template<UIPanel_Inventory> {

	private UIButton[] _tabs;
	private int currentTab = 0;
	[SerializeField]
	private GameObject[] _lists;
	[SerializeField]
	private GameObject[] _bars;

	protected override void init()
	{
		base.init();

		_tabs = this.GetComponentsInChildren<UIButton>();

		for (int i = 0; i < _tabs.Length; i++)
		{
			EventDelegate btnEvent = new EventDelegate(this, "TabClick");
			btnEvent.parameters[0] = new EventDelegate.Parameter(i);
			_tabs[i].onClick.Add(btnEvent);
			print(_tabs[i].defaultColor);
			_tabs[i].defaultColor = new Color(_tabs[i].defaultColor.r, _tabs[i].defaultColor.g, _tabs[i].defaultColor.b, 0.5f);
			print(_tabs[i].defaultColor);
		}

		_tabs[0].defaultColor = new Color(_tabs[0].defaultColor.r, _tabs[0].defaultColor.g, _tabs[0].defaultColor.b, 1);
		_tabs[0].enabled = false;

		_lists[1].SetActive(false);
		_lists[2].SetActive(false);
		_bars[1].SetActive(false);
		_bars[2].SetActive(false);
	}

	public void TabClick(int clickTab)
	{
		_tabs[currentTab].enabled = true;
		_tabs[currentTab].defaultColor = new Color(_tabs[currentTab].defaultColor.r, _tabs[currentTab].defaultColor.g, _tabs[currentTab].defaultColor.b, 0.5f);
		_tabs[clickTab].enabled = false;
		_tabs[clickTab].defaultColor = new Color(_tabs[clickTab].defaultColor.r, _tabs[clickTab].defaultColor.g, _tabs[clickTab].defaultColor.b, 1);
		currentTab = clickTab;
		for (int i = 0; i < _tabs.Length; i++)
		{
			_lists[i].SetActive(i == clickTab);
			_bars[i].SetActive(i == clickTab);
		}
	}
}
