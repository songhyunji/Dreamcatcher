using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class Item // Json 파일에 데이터를 저장하기 위하여 클래스 정의
{

	public int type;
	public string name;

	public Item(int t, string n)
	{
		type = t;
		name = n;
	}
}

public class Inventory : MonoBehaviour
{
	public Sprite key;
	public Sprite lily;
	public Sprite none;

	public GameObject inventory;
	[SerializeField]
	private Image invenImg;
	private int i;

	public List<Item> ItemList = new List<Item>(); // 사용자가 정의한 데이터를 담고 있는 리스트

	private void Start()
	{
		inventory = GameObject.FindWithTag("Inventory");
		invenImg = inventory.GetComponent<Image>();
		LoadFunc();
	}

	public void SaveItem(int num)
	{
		i = PlayerPrefs.GetInt("itemNum");

		switch (num)
		{
			case 0:
				ItemList.Clear();
				PlayerPrefs.SetInt("itemNum", 0);
				invenImg.sprite = key;
				break;
			case 1:
				ItemList.Add(new Item(i, "key"));
				PlayerPrefs.SetInt("itemNum", i++);
				invenImg.sprite = key;
				break;
			case 2:
				ItemList.Add(new Item(i, "lily"));
				PlayerPrefs.SetInt("itemNum", i++);
				invenImg.sprite = lily;
				break;
			default:
				break;
		}

		SaveFunc();
	}

	public void SaveFunc()
	{
		JsonData ItemJson = JsonMapper.ToJson(ItemList); // Json 파일에 저장된 데이터가 담긴 리스트 배열을 JsonMapper.ToJson(); 메소드를 사용하며 Json Data로 변환
		File.WriteAllText(Application.dataPath + "/Resource/item_data.Json", ItemJson.ToString()); // Json Data로 변환된 데이터의 문자열을 이용해서 Json 파일 생성

		LoadFunc();
	}

	public void LoadFunc()
	{
		Debug.Log("Load");
		StartCoroutine(LoadCol());
	}

	IEnumerator LoadCol()
	{
		string JsonString = File.ReadAllText(Application.dataPath + "/Resource/item_data.Json");
		Debug.Log(JsonString); // string data가 저장이 안 됨.

		JsonData itemData = JsonMapper.ToObject(JsonString); // string 타입으로 된 데이터를 JsonData로 맵핑
		ParsingJsonItem(itemData);
		yield return null;
	}

	private void ParsingJsonItem(JsonData name)
	{
		for(int i = 0; i < name.Count; i++)
		{
			string TmpID = name[i]["type"].ToString();

			for(int j = 0; j < ItemList.Count; j++)
			{
				if(TmpID==ItemList[j].type.ToString())
				{
					Debug.Log(ItemList[i].name);
				}
			}

		}
	}
}