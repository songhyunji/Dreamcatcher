using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    GameObject inventoryCanvas;
    GameObject inventoryBackground;
    GameObject slotPanel;
    GameObject textPanel;
    Database database;

    private int slotAmount;
    private bool isActivated;
    public List<Item> items = new List<Item>();
    public List<GameObject> slots = new List<GameObject>();

    private void Start()
    {
        database = GetComponent<Database>();
        slotAmount = 6;
        isActivated = false;
        inventoryCanvas = GameObject.Find("InventoryCanvas");
        inventoryBackground = inventoryCanvas.transform.Find("Inventory_Background").gameObject;
        slotPanel = inventoryBackground.transform.Find("Slot_Panel").gameObject;
        textPanel = inventoryBackground.transform.Find("Text_Panel").gameObject;
        inventoryBackground.SetActive(false);
        InitializeItem();
    }

    public void InitializeItem()
    {
        for(int i = 0;i<database.items.Count;i++)
        {
            Item itemObj = slotPanel.transform.GetChild(i).GetComponent<Item>();
            itemObj.itemID = database.items[i].itemID;
            itemObj.itemName = database.items[i].itemName;
            itemObj.itemDescription = database.items[i].itemDescription;
            itemObj.isActivated = database.items[i].isActivated;
        }
    }
    public void pressInvenBtn()
    {
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

    public void pressSlotBtn()
    {
        textPanel.transform.GetChild(0).GetComponent<Text>().text = transform.GetChild(0).GetComponent<Item>().itemName;
        textPanel.transform.GetChild(1).GetComponent<Text>().text = transform.GetChild(0).GetComponent<Item>().itemDescription;
    }

    public void ActivatedItem(int id)
    {
        //database를 true로 수정
        items[id].isActivated = true;
        items[id].activatedItem();
        
    }

    private void Update()
    {
        
    }
}
