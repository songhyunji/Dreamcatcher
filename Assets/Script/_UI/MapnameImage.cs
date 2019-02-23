using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapnameImage : MonoBehaviour
{
    public float speed = 0.015f; // fade out 되는 속도
    float alpha = 1.5f; // 투명도

//    public Image image;

    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        //        this.GetComponent<Image>().color.a = alpha;
        this.GetComponent<Image>().CrossFadeAlpha(alpha, 0f, true);

        alpha -= speed;
    }
}
