using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFade : MonoBehaviour
{
    //Vector2 SizeVector = new Vector2(Screen.width, Screen.height);

    float alpha = 1.5f;
    public float speed = 0.015f;

    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<RectTransform>().sizeDelta = SizeVector; // 스크린 사이즈와 동일하게 사이즈 맞추기
        
    }

    // Update is called once per frame
    void Update()
    {
		if(alpha>=0)
		{
			this.GetComponent<Image>().CrossFadeAlpha(alpha, 0f, true);

			alpha -= speed;
		}
    }
}
