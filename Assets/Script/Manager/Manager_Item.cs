using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

[Serializable]
public class ItemData
{
	public string _code;
	public string _name;
	public string _price;
}

[Serializable]
public class Json_ItemData
{
	public List<ItemData> Hair;
	public List<ItemData> Skin;
}

public class Manager_Item : Manager_Template<Manager_Item>
{
	private GameObject[] _hairList;
	private GameObject[] _wingList;
	private GameObject[] _weaponList;
	private Material[] _skinList;

	private Json_ItemData _itemData;

	protected override void Init()
	{
		base.Init();	

		_hairList = Resources.LoadAll<GameObject>("Item/Hair");
		_skinList = Resources.LoadAll<Material>("Item/Skin");

		TextAsset jsonText = (TextAsset)Resources.Load("JsonFiles/ItemList");

		_itemData = JsonUtility.FromJson<Json_ItemData>(jsonText.text);
	}

	//public void CreateItem(Transform attachTrans, string code)
	//{
	//	int type = Convert.ToInt32(code[0]);
	//	if (type == 1) return;

	//	GameObject createItem = null;
	//	switch (type)
	//	{
	//		case 0:
	//			//Hair
	//			createItem = _hairList[Convert.ToInt32(code.Substring(1))];
	//			break;
	//		case 2:
	//			//Wing
	//			createItem = _wingList[Convert.ToInt32(code.Substring(1))];
	//			break;
	//		case 3:
	//			//Weapon
	//			createItem = _weaponList[Convert.ToInt32(code.Substring(1))];
	//			break;
	//	}

	//	GameObject gObj = Instantiate(createItem);
	//	gObj.transform.SetParent(attachTrans);
	//	gObj.transform.localPosition = Vector3.zero;
	//	gObj.transform.localRotation = Quaternion.Euler(-90, 0, 0);
	//}

	//public void CreateSkinModel(Transform createTrans, string skinCode)
	//{
		
	//}

	public void ChangeSkin(GameObject attachBody, string skinCode)
	{
		int code = Convert.ToInt32(skinCode.Substring(1));
		MeshRenderer renderer = attachBody.GetComponentInChildren<MeshRenderer>();
		renderer.material = _skinList[code];
	}

	public GameObject CreateItem(string itemCode)
	{
		GameObject createItem;
		int type = int.Parse(itemCode[0].ToString());
		switch (type)
		{
			case 0:
				//Hair
				createItem = _hairList[Convert.ToInt32(itemCode.Substring(1))];
				break;
			case 2:
				//Wing
				createItem = _wingList[Convert.ToInt32(itemCode.Substring(1))];
				break;
			case 3:
				//Weapon
				createItem = _weaponList[Convert.ToInt32(itemCode.Substring(1))];
				break;
			default:
				createItem = null;
				break;
		}
		createItem = Instantiate(createItem);
		return createItem;
	}
}
