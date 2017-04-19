using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_List : MonoBehaviour
{
	static private Camera _viewCam;
	private GameObject _player;
	private List<string> _playerInven;
	private int _itemCount;
	private List<string> _itemList;
	private List<GameObject> _viewObjectList;
	private List<RenderTexture> _viewTextureList;
	private List<GameObject> _slotList;
	private GameObject _slotBase;
	private GameObject _viewObjectZone;

	private void Awake()
	{
		if (_viewCam == null)
		{
			GameObject gObj = new GameObject("ItemViewCam");
			_viewCam = gObj.AddComponent<Camera>();
			_viewCam.cullingMask = LayerMask.NameToLayer("Item");
		}
			
		Item_Inventory _inventory;
		_inventory = _player.GetComponent<Item_Inventory>();
		switch (this.gameObject.name)
		{
			case "Hair":
				_playerInven = _inventory.Data._liftHairList;
				_viewObjectZone = new GameObject("HairZone");
				break;
			case "Skin":
				_playerInven = _inventory.Data._liftSkinList;
				_viewObjectZone = new GameObject("SkinZone");
				break;
			case "Wing":
				_playerInven = _inventory.Data._liftWingList;
				_viewObjectZone = new GameObject("WingZone");
				break;
		}
		_viewObjectZone.transform.position = new Vector3(2000, 2000, 2000);
		
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
					슬롯 추가. 
					 */
					GameObject gObj = Instantiate(_slotBase);
					gObj.transform.SetParent(this.transform);
					gObj.transform.localPosition = Vector3.zero;
					_slotList.Add(gObj);
					/*
					뷰오브젝트 추가.
					*/
					GameObject createItem = Manager_Item.Instance.CreateItem(_playerInven[i]);
					createItem.transform.SetParent(_viewObjectZone.transform);
					createItem.transform.localPosition = Vector3.zero;
					_viewObjectList.Add(createItem);
					_viewTextureList.Add(new RenderTexture(300, 300, 0));
					_viewCam.targetTexture = _viewTextureList[i];
					_viewCam.Render();

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
