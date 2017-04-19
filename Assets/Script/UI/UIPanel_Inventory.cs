using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel_Inventory : UIPanel_Template<UIPanel_Inventory> {

	private UIButton[] _tabs;
	private int currentTab = 0;
	[SerializeField]
	private GameObject[] _lists;

	protected override void init()
	{
		base.init();

		_tabs = this.GetComponentsInChildren<UIButton>();

		for (int i = 0; i < _tabs.Length; i++)
		{
			EventDelegate btnEvent = new EventDelegate(this, "TabClick");
			btnEvent.parameters[0] = new EventDelegate.Parameter(i);
			_tabs[i].onClick.Add(btnEvent);
		}

		_lists[1].SetActive(false);
		_lists[2].SetActive(false);
	}

	public void TabClick(int clickTab)
	{
		_tabs[currentTab].enabled = true;
		_tabs[clickTab].enabled = false;

		for (int i = 0; i < _tabs.Length; i++)
		{
			_lists[i].SetActive(i == clickTab);
		}
	}
}
