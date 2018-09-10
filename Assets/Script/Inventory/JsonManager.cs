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
    string content;                                                                     //Save할 JsonData의 string
    public Text testText;                                                               //Test용 text 연결
    public Text gamingTestText;                                                         //Test용 text 연결
    string text;                                                                        //데이터 save할 때 json data를 임시 저장
    TextAsset userItemFile;
    bool wantNewGame = false;
    
    public void LoadNewGame()
    {   //새 게임 로드
        wantNewGame = true;
        itemLoad();
        wantNewGame = false;
    }

    public void itemLoad()
    {   // 저장된 item data를 inventory list에 로드 
        if(!File.Exists(Application.persistentDataPath + "/UserInventory.json") || wantNewGame)
        {   //파일이 존재하지 않는다 -> Origin값을 복사해와서 user전용 json 파일 생성 후 불러오기
            userItemFile = Resources.Load("Inventory/OriginItems") as TextAsset;
            content = userItemFile.ToString();
            File.WriteAllText(Application.persistentDataPath + "/UserInventory.json", content);
        }
        else
        {   //파일이 존재한다 -> 기존 json 파일 값 불러오기
            content = File.ReadAllText(Application.persistentDataPath + "/UserInventory.json");
        }

        JsonData getData = JsonMapper.ToObject(content);

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
        content = JsonConvert.SerializeObject(inventoryItems);
        File.WriteAllText(Application.persistentDataPath + "/UserInventory.json", content);
    }

}
