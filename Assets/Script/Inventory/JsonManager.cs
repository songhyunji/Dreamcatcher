using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.UI;
using System;

public class JsonManager : MonoBehaviour {

    public List<Item> inventoryItems = new List<Item>();                                //저장된 data를 로드할 리스트
    WWW itemPath;                                                                       //json data가 저장된 경로 지정
    WWW originPath;                                                                     //새로 시작할 경우 불러올 original item file
    JsonData getData;                                                                   //load시 경로따라 저장하는 json file
    string dataJason;                                                                   //Save할 JsonData의 string
    public Text testText;                                                               //Test용 text 연결
    public Text gamingTestText;                                                         //Test용 text 연결
    string text;                                                                        //데이터 save할 때 json data를 임시 저장
    
    public void startNewGameAboutItem()
    {   //새로 게임을 시작했을 때, 기존의 아이템 DB를 지우고 originData를 덮어씁니다.
#if UNITY_ANDROID
        originPath = new WWW(Application.streamingAssetsPath + "/Inventory/OriginItems.json");
        itemPath = new WWW(Application.streamingAssetsPath + "/Inventory/UserInventory.json");

        File.Copy(originPath, itemPath, true);
#else
        File.Copy(Application.streamingAssetsPath + "/Inventory/OriginItems.json", Application.streamingAssetsPath + "/Inventory/UserInventory.json", true);
#endif
        itemLoad();
    }
    
    public void itemLoad()
    {   // 저장된 item data를 inventory list에 로드
        itemPath = new WWW(Application.streamingAssetsPath + "/Inventory/UserInventory.json");
        getData = JsonMapper.ToObject(itemPath.text);

        if (inventoryItems.Count != 0)
        {   //이미 인벤토리아이템에 기존 아이템이 저장되어있다면 모두 삭제
            inventoryItems.Clear();
        }
        text = null;
        for(int i = 0; i<getData.Count; i++)
        {
            Item loadItem = new Item();
            loadItem.id = (int)getData[i]["id"];
            loadItem.name = getData[i]["name"].ToString();
            loadItem.description = getData[i]["description"].ToString();
            loadItem.activated = (int)getData[i]["activated"];
            inventoryItems.Add(loadItem);
            text += (inventoryItems[i].activated == 1 ? "true" : "false") + "   ";
        }
        gamingTestText.text = text;
        testText.text = text;
    }


    public void itemSave()
    {   // inventory list의 값을 json으로 저장 : Newtonsoft.JSON으로 serialize
        dataJason = JsonConvert.SerializeObject(inventoryItems);
        File.WriteAllText(Application.platform == RuntimePlatform.Android ? itemPath.text : Application.streamingAssetsPath + "/Inventory/UserInventory.json", dataJason);
    }

}
