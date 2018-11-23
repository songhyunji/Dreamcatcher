using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractButton : MonoBehaviour //, IPointerDownHandler
{

    public GameObject player;
    public Player_subslope playerScript;

    public GameObject Dor; // 도르래
    public Sprite Dor1, Dor2; // 변환 전, 변환 후
    private SpriteRenderer Dorimg;
    private bool DorOn = false;


	// Use this for initialization
	void Start () {
		
	}

    public void OnPointerDown(PointerEventData ped)
    {
        Debug.Log("인터랙트");

        // 도르래 오브젝트와 x좌표가 같다면
        if (player.transform.position.x == Dor.transform.position.x)
        {

            // 도르래가 작동하고 있는 상태 : DorOn = true; -> 꺼줌
            if (DorOn)
            {
                Dorimg.sprite = Dor1;
                DorOn = false;
            }
            // 도르래가 작동하고 있지 않는 상태 : DorOn = false; -> 켜줌
            else
            {
                Dorimg.sprite = Dor2;
                DorOn = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
