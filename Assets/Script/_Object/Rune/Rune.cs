using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public GameObject player;

    public bool isTouch = false;

    public Sprite Runeoff, Runeon; // 룬 꺼짐, 룬 켜짐
    public SpriteRenderer Runeimg;
    public bool RuneSwitch = true; // 룬이 켜지면 1, 룬이 꺼지면 0


    // 만약 플레이어가 룬의 위치와 같을 때
    // 플레이어가 인터랙트 버튼을 누르면 룬 불빛이 켜짐 -> 꺼짐
    // 켜져 있을 때에는 주변으로 빛이 나온당 (이펙트)
    // 꺼지면 빛도 꺼진당

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // 인터랙션 버튼을 누르면
    public void PressInteractBtn()
    {
        if (isTouch == true)
        {
            Debug.Log("인터랙션 버튼 누름");

            if (RuneSwitch) // 룬이 켜져 있음
            {
                Runeimg.sprite = Runeoff;
                RuneSwitch = false;
                Debug.Log("룬 꺼짐");

            }
            else // 룬이 꺼져 있음
            {
                Runeimg.sprite = Runeon;
                RuneSwitch = true;
                Debug.Log("룬 켜짐");
            }

            isTouch = false;

        } // + 포인트 라이트도 끄기
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // 룬이 플레이어와 닿았을 때
        if (other.gameObject == player)
        {
            Debug.Log("룬과 충돌");

            isTouch = true;
        }
    }

}