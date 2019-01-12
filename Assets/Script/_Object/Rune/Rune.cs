using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : MonoBehaviour
{
    public GameObject player;
    public GameObject lightParticle;

    public Enterence enterenceScript;
    public MovingPlatform movingPlatformScript;

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
        player = GameObject.Find("TestPlayer");
        // 전 스테이지에서 넘어오는 플레이어 오브젝트 찾기
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
                lightParticle.SetActive(false); // 포인트 라이트도 끄기
            }
            else // 룬이 꺼져 있음 -> 룬이 다시 켜지지 않음
            {
                //Runeimg.sprite = Runeon;
                //RuneSwitch = true;
                //Debug.Log("룬 켜짐");
            }

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // 룬이 플레이어와 닿았을 때
        if (other.CompareTag("Player"))
        {
            Debug.Log("룬과 충돌");

            isTouch = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        // 룬이 플레이어와 닿았을 때
        if (other.CompareTag("Player"))
        {
            Debug.Log("룬과 충돌 안 함");

            isTouch = false;
        }
    }

}