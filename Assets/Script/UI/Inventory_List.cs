using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_List : MonoBehaviour
{
	private GameObject _player;
	private List<string> _playerInven;
	private int _itemCount;
	private List<string> _itemList;
	private List<GameObject> _viewObject;
	private List<GameObject> _slotList;

	private void Awake()
	{
		Item_Inventory _inventory;
		_inventory = _player.GetComponent<Item_Inventory>();
		switch (this.gameObject.name)
		{
			case "Hair":
				_playerInven = _inventory.Data._liftHairList;
				break;
			case "Skin":
				_playerInven = _inventory.Data._liftSkinList;
				break;
			case "Wing":
				_playerInven = _inventory.Data._liftWingList;
				break;
		}
		Refresh();
	}
	private void Refresh()
	{
		if (_itemCount != _playerInven.Count)
		{
			int gap = _playerInven.Count - _itemCount;
			for (int i = 0; i < _playerInven.Count; i++)
			{
				if (!_itemList.Contains(_playerInven[i]))
				{
					_itemList.Add(_playerInven[i]);
					/*
					뷰오브젝트 추가.
					슬롯 추가. 
					 */

					gap--;
					if (gap <= 0)
					{
						_itemCount = _itemList.Count;
						return;
					}
				}
			}
		}
	}
}
