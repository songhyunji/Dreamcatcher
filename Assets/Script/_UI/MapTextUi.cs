using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapTextUi : MonoBehaviour
{
    public float speed = 0.015f; // fade out 되는 속도
    float alpha = 1.5f; // 투명도
    string currentmap = " "; // 현재 맵 이름
    string currentscene; // 현재 씬 이름

    // Start is called before the first frame update
    void Start()
    {
        currentscene = SceneManager.GetActiveScene().name; // 현재 활성화된 씬 이름 불러오기
        //center에 뜨는 ui의 경우 string의 첫 글자를 따서 A면 마녀의 숲, B면 -- 식으로 띄우기
        DecideMapName();

    }

    // Update is called once per frame
    void Update()
    {

        this.GetComponent<Text>().text = currentmap; // ui text 업데이트

//        Debug.Log(this.GetComponent<Text>().color.a);

        this.GetComponent<Text>().color = new Color(255, 255, 255, alpha);
        //        this.GetComponent<Text>().color = new Color(255, 255, 255, 1);

        if (alpha <= 1.5 && alpha > -1)
        { // alpha가 1보다 작고 0보다 크면
          //(1.5 : 텍스트 유지되는 시간(1~2초), 1.5에서 1.0으로 바뀌면 점점 사라지기 시작함)
            alpha -= speed;
  //          Debug.Log(alpha);
        }
        else
//            alpha = 1; // 반복 테스트용
            alpha = 0; // 사라지기 끝나면 계속 투명한 상태로

    }

    void DecideMapName() // 맵 이름 정하는 함수
    {
        switch(currentscene) // 씬 이름에 따라 맵 이름 정함
        {
            case "A1":
                currentmap = "마녀의 숲 입구 - 1";
                break;
            case "A2":
                currentmap = "마녀의 숲 입구 - 2";
                break;
            case "B1":
                currentmap = "마녀의 숲 - 1";
                break;
            case "B2":
                currentmap = "마녀의 숲 - 2";
                break;
            case "B3":
                currentmap = "마녀의 숲 - 3";
                break;
            case "B4":
                currentmap = "마녀의 숲 - 4";
                break;
            case "B5":
                currentmap = "마녀의 숲 - 5";
                break;
            case "B6":
                currentmap = "마녀의 숲 - 6";
                break;

        }
    }
}
