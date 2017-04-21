using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : MonoBehaviour
{
	private GameObject _player; /* 나중에 제거*/
	private List<string> _playerInven;
	private int _itemCount = 0;
	private List<string> _itemList;
	private List<Texture> _viewTextureList;
	private List<GameObject> _slotList;
	private GameObject _slotBase;
	private GameObject _viewObjectZone;
	private string _currentItem;
	private int _index;
	Item_Inventory _inventory;

	private void Awake()
	{
		_itemList = new List<string>();
		_viewTextureList = new List<Texture>();
		_slotList = new List<GameObject>();

		_player = GameObject.Find("Player");
		_inventory = _player.GetComponent<Item_Inventory>();
		switch (this.gameObject.name)
		{
			case "Hair":
				_playerInven = _inventory.Data._liftHairList;
				_viewObjectZone = new GameObject("HairZone");
				_currentItem = _inventory.Data._currentItem[_index=(int)ITEMTYPE.HAIR];
				break;
			case "Skin":
				_playerInven = _inventory.Data._liftSkinList;
				_viewObjectZone = new GameObject("SkinZone");
				_currentItem = _inventory.Data._currentItem[_index=(int)ITEMTYPE.SKIN];
				break;
			case "Wing":
				_playerInven = _inventory.Data._liftWingList;
				_viewObjectZone = new GameObject("WingZone");
				_currentItem = _inventory.Data._currentItem[_index=(int)ITEMTYPE.WING];
				break;
		}
		_viewObjectZone.transform.position = new Vector3(2000, 2000, 2000);
		
		Refresh();
	}
	private void Refresh()
	{
		Debug.Log("새로고침");
		//if (_currentItem != _inventory.Data._currentItem[_index])
		//{
		//	/*
		//		현재아이템 띄우기.
		//	*/
		//}
		if (_itemCount != _playerInven.Count)
		{
			for (int i = _itemCount; i < _playerInven.Count; i++)
			{
				_itemList.Add(_playerInven[i]);
				ItemData itemData = Manager_Item.Instance.GetItemData(_itemList[i]);
				/*
				슬롯 추가. 
				 */
				GameObject gObj = Instantiate(_slotBase);
				gObj.name = _playerInven[i];
				gObj.transform.SetParent(this.transform);
				gObj.transform.localPosition = Vector3.zero;
				_viewTextureList.Add(Manager_Item.Instance.GetTexture(_playerInven[i]));
				UITexture texture = gObj.GetComponent<UITexture>();
				texture.mainTexture = _viewTextureList[i];
				UILabel[] label = gObj.GetComponentsInChildren<UILabel>();
				for (int j = 0; j < label.Length; j++)
				{
					if (label[j].name == "ItemName")
						label[j].text = itemData._name;
					else
						label[j].text = "옵션";
				}
				_slotList.Add(gObj);
			}
		}
	}
}
