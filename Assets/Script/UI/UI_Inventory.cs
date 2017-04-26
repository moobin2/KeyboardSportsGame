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
	private GameObject _currentSlot;
	private GameObject _viewObjectZone;
	private string _currentItem;
	private int _index;
	Item_Inventory _inventory;

	private void Awake()
	{
		_itemList = new List<string>();
		_viewTextureList = new List<Texture>();
		_slotList = new List<GameObject>();

		_player = Manager_Game.Player;
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

		_slotBase = Resources.Load<GameObject>("GUI/Inventory/Slot");

		#region 현재아이템 슬롯 만들기
		ItemData itemData = Manager_Item.Instance.GetItemData(_currentItem);
		_currentSlot = Instantiate(_slotBase);
		_currentSlot.name = _currentItem;
		_currentSlot.transform.SetParent(this.transform);
		_currentSlot.transform.localPosition = Vector3.zero;
		_currentSlot.transform.localScale = new Vector3(1, 1, 1);

		//_viewTextureList.Add(Manager_Item.Instance.GetTexture(_playerInven[i]));
		UITexture texture = _currentSlot.GetComponent<UITexture>();
		//texture.mainTexture = _viewTextureList[i];
		UILabel[] label = _currentSlot.GetComponentsInChildren<UILabel>();
		for (int j = 0; j < label.Length; j++)
		{
			if (label[j].name == "ItemName")
				label[j].text = itemData._name;
			else
				label[j].text = "착용중";
		}
		_slotList.Add(_currentSlot);
		#endregion


		Refresh();
	}
	private void Refresh()
	{
		Debug.Log("새로고침");
		if (_currentItem != _inventory.Data._currentItem[_index])
		{
			/*
				현재아이템 띄우기.
			*/

			
		}
		print(_playerInven.Count);
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
				gObj.transform.localScale = new Vector3(1, 1, 1);
				//_viewTextureList.Add(Manager_Item.Instance.GetTexture(_playerInven[i]));
				UITexture texture = gObj.GetComponent<UITexture>();
				//texture.mainTexture = _viewTextureList[i];
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
