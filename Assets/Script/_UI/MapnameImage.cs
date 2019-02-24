using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapnameImage : MonoBehaviour
{
    public float speed = 0.015f; // fade out 되는 속도
    public float alpha = 0f; // 투명도

    public Sprite image; // stage title image

	public bool startFade;
    

//    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Image>().sprite = image; // title image 지정

    }

    // Update is called once per frame
    void Update()
    {
        //        this.GetComponent<Image>().color.a = alpha;
		if(startFade)
		{            
            alpha = 1.5f;
            startFade = false;

            Debug.Log("알파값 변경");
        }

//        Debug.Log("현재 알파값 : "+ alpha);

        this.GetComponent<Image>().CrossFadeAlpha(alpha, 0f, true);
        alpha -= speed;

    }
}
