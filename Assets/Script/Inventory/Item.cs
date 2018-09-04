using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item{
    /*
    GameObject item_Icon;
    GameObject textPanel;
    */
    public int id { get; set; }  
    public string name { get; set; }
    public string description { get; set; }
    public int activated { get; set; }                //bool로 지정하면 나중에 직렬화 후 Json 저장이 좀 골치아파집니다... 숫자로 지정하도록 할게요.

    /*

	void Start () {
        item_Icon = transform.Find("Item_Icon").gameObject;
        textPanel = transform.parent.parent.Find("Text_Panel").gameObject;
        //database에서 isActivated 값을 받아옴
	}
	
    public void ItemActivated()
    {   //inventory의 activatedItem에 의해 실행됩니다.
        item_Icon.SetActive(true);
        isActivated = true;
        //database에 isActivated 값을 반영함
    }

    public void pressSlotBtn()
    {//해당 슬롯을 누르면 알맞은 아이템 이름과 설명이 text에 덮어씌워집니다. 역시 Button의 OnClick() 실행 메소드입니다.
        textPanel.transform.GetChild(0).GetComponent<Text>().text = itemName;
        textPanel.transform.GetChild(1).GetComponent<Text>().text = itemDescription;
    }*/
}
