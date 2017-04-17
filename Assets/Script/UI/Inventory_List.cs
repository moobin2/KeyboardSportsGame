using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_List : MonoBehaviour
{
	private GameObject _player;
	private Item_Inventory _inventory;
	private int _itemCount;
	[SerializeField]
	private int _index;
	private List<string> _itemList;

	private void Awake()
	{
		_inventory = _player.GetComponent<Item_Inventory>();

		Refresh();
	}
	private void Refresh()
	{
		if (_itemCount != _inventory.Data._liftHairList.Count)
		{
			for (int i = 0; i < _inventory.Data._liftHairList.Count; i++)
			{
				if (!_itemList.Contains(_inventory.Data._liftHairList[i]))
				{
					_itemList.Add(_inventory.Data._liftHairList[i]);
				}
			}
			_itemCount = _itemList.Count;
		}
	}
}
