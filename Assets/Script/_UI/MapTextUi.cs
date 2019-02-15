using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapTextUi : MonoBehaviour
{
    float speed = 0.1f; // fade out 되는 속도
    float alpha = 0; // 투명도
    string currentmap = " "; // 현재 맵 이름
    string currentscene; // 현재 씬 이름

    // Start is called before the first frame update
    void Start()
    {
        currentscene = SceneManager.GetActiveScene().name; // 현재 활성화된 씬 이름 불러오기
        //center에 뜨는 ui의 경우 string의 첫 글자를 따서 A면 마녀의 숲, B면 -- 식으로 띄우기

    }

    // Update is called once per frame
    void Update()
    {
        DecideMapName();

        this.GetComponent<Text>().text = currentmap; // ui text 업데이트

        this.GetComponent<Text>().color = new Color(255, 255, 255, alpha);

        if (alpha < 1) // alpha가 1보다 작으면
            alpha -= speed;
        else
            alpha = 0;
    }

    void DecideMapName() // 맵 이름 정하는 함수
    {
        switch(currentscene) // 씬 이름에 따라 맵 이름 정함
        {
            case "A1":
                currentmap = "마녀의 숲 - 1";
                break;
            case "A2":
                currentmap = "마녀의 숲 - 2";
                break;
            case "B1":
                currentmap = "마녀의 숲 - 2";
                break;
            case "B2":
                currentmap = "마녀의 숲 - 2";
                break;
            case "B3":
                currentmap = "마녀의 숲 - 2";
                break;
            case "B4":
                currentmap = "마녀의 숲 - 2";
                break;

        }
    }
}
