using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChangeTest : MonoBehaviour {

    JsonManager jm;
    string s;
    

    private void Start()
    {
        jm = GameObject.Find("ItemDBManager").GetComponent<JsonManager>();
    }
    public void changeActivated()
    {   //플레이 중 활성화 값 변경 테스트 메소드
        s = null;
        int i = int.Parse(transform.GetChild(0).GetComponent<Text>().text);
        jm.inventoryItems[i].activated = jm.inventoryItems[i].activated == 1 ? 0 : 1;
        for (int x = 0; x < jm.inventoryItems.Count; x++)
        {
            s += (jm.inventoryItems[x].activated == 1 ? "true" : "false") + "    ";
        }
        jm.gamingTestText.text = s;
    }
}
