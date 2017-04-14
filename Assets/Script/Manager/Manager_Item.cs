using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Json_ItemData
{
	public List<ItemBase> Hair;
	public List<ItemBase> Skin;
}

public class Manager_Item : Manager_Template<Manager_Item>
{
	private GameObject[] _hairList;
	private GameObject[] _wingList;
	private Material[] _skinList;

	private Json_ItemData _itemData;

	protected override void Init()
	{
		base.Init();

		_hairList = Resources.LoadAll<GameObject>("Item/Hair");
		_skinList = Resources.LoadAll<Material>("Item/Skin");

		TextAsset jsonText = (TextAsset)Resources.Load("JsonFiles/ItemList");

		_itemData = JsonUtility.FromJson<Json_ItemData>(jsonText.text);
		Debug.Log(_itemData.Hair.Count);
		Debug.Log(_itemData.Hair[1]._name);
	}

	public void CreateHair(GameObject character, int hairCode)
	{
		Transform attachTrans = character.transform.FindChild("RigPelvis/RigSpine1/RigSpine2/RigRibcage/RigNeck/RigHead/Dummy Prop Head");

		Transform[] searchTrans = attachTrans.GetComponentsInChildren<Transform>();

		for (int i = 1; i < searchTrans.Length; i++)
		{
			string name = searchTrans[i].name;
			if (-1 != name.IndexOf("Hair"))
			{
				Destroy(searchTrans[i].gameObject);
			}
		}

		GameObject gObj = Instantiate(_hairList[hairCode]);
		gObj.transform.SetParent(attachTrans);
		gObj.transform.localPosition = Vector3.zero;
		gObj.transform.localRotation = Quaternion.Euler(-90, 0, 0);
	}

	public void ChangeSkin(GameObject character, int skinCode)
	{
		SkinnedMeshRenderer mesh = character.GetComponentInChildren<SkinnedMeshRenderer>();
		mesh.material = _skinList[0];
	}

	public void CreateWing(GameObject character, int wingCode)
	{

	}
}
