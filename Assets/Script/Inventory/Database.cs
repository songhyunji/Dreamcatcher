using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Database : MonoBehaviour {

    public List<Item> items = new List<Item>();
    private JsonData itemData;

	// Use this for initialization
	void Start () {
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        ConstructItemDatabase();
	}



	
    void ConstructItemDatabase()
    {
        for(int i = 0; i<itemData.Count;i++)
        {
            Item newItem = new Item();
            newItem.itemID = (int)itemData[i]["id"];
            newItem.isActivated = (bool)itemData[i]["activated"];
            newItem.itemName = itemData[i]["name"].ToString();
            newItem.itemDescription = itemData[i]["description"].ToString();

            items.Add(newItem);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
