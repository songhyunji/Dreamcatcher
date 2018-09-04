﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameObject inventoryCanvas;                     
    GameObject inventoryBackground;
    GameObject slotPanel;
    GameObject textPanel;
    Database database;

    private bool isActivated;   //인벤토리 활성화 여부 저장하는 boolean
    public List<Item> items = new List<Item>();     //미구현이라 아직 사용하진 않는데 일단 냅뒀습니다.
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        database = GetComponent<Database>();

        inventoryCanvas = GameObject.Find("InventoryCanvas");
        inventoryBackground = inventoryCanvas.transform.Find("Inventory_Background").gameObject;
        slotPanel = inventoryBackground.transform.Find("Slot_Panel").gameObject;
        textPanel = inventoryBackground.transform.Find("Text_Panel").gameObject;

        isActivated = false;    //인벤토리 초기 값은 비활성화입니다.
        inventoryBackground.SetActive(false);

        InitializeItem();

    }

    public void InitializeItem()
    {   //database의 모든 item의 정보를 읽어옵니다. slotPanel의 자식인 slot들에 값이 저장됩니다.
        for (int i = 0;i<database.databaseItems.Count;i++)
        {

            Item itemObj = slotPanel.transform.GetChild(i).GetComponent<Item>();
            itemObj.id = database.databaseItems[i].id;
            itemObj.name = database.databaseItems[i].name;
            itemObj.description = database.databaseItems[i].description;
            itemObj.activated = database.databaseItems[i].activated;

        }
    }
    public void pressInvenBtn()
    {   //인벤 활성화/비활성화를 다룹니다. 인벤토리 아이콘의 Button OnClick() 실행 메소드입니다.
        isActivated = !isActivated;
        if(isActivated)
        {   //인벤 팝업
            textPanel.transform.GetChild(0).GetComponent<Text>().text = "";
            textPanel.transform.GetChild(1).GetComponent<Text>().text = "";

            inventoryBackground.SetActive(true);

        }
        else
        {
            inventoryBackground.SetActive(false);
        }
    }
}
