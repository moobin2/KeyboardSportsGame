using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ITEMTYPE
{
	HAIR = 0,
	SKIN,
	WING,
	WEAPON,

	MAXITEM
}

[Serializable]
public class InventoryData
{
	public List<string> _liftHairList;
	public List<string> _liftSkinList;
	public List<string> _liftWingList;
	public List<string> _liftWeaponList;
	public List<string> _currentItem;
}

public class Item_Inventory : MonoBehaviour
{
	private InventoryData _data;
	public InventoryData Data
	{
		get
		{
			return _data;
		}
	}

	private void Awake()
	{
		TextAsset jsonText = (TextAsset)Resources.Load("JsonFiles/UserInfo");
		_data = JsonUtility.FromJson<InventoryData>(jsonText.text);
		print(_data._liftHairList.Count);
	}
}
