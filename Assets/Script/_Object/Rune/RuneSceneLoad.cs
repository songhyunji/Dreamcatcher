using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSceneLoad : MonoBehaviour
{
    public Rune runeScript;

    // Start is called before the first frame update
    void Start()
    {
        runeScript.player = GameObject.Find("TestPlayer");
        // 전 스테이지에서 넘어오는 플레이어 오브젝트 찾기
    }

    // Update is called once per frame
    void Update()
    {

    }
}