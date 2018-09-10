using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class Database : MonoBehaviour
{

    public List<Item> databaseItems = new List<Item>();
    private JsonData itemData;

    // Use this for initialization
    void Awake()
    {
        //Start()로 하면 Inventory의 InitializeItem()이 먼저 실행되는 경우가 있어서 Awake 사용함
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        FirstConstructItems();
    }


    public void FirstConstructItems()
    {   //게임 첫 실행에서만 저장됩니다.
        //해당 Path의 파일 내용을 읽어들여 item형 list에 Add합니다.
        for (int i = 0; i < itemData.Count; i++)
        {
            Item item = new Item();
            item.id = (int)itemData[i]["id"];
            item.activated = (int)itemData[i]["activated"];
            item.name = itemData[i]["name"].ToString();
            item.description = itemData[i]["description"].ToString();

            databaseItems.Add(item);
        }


    }
}
