using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enterence : MonoBehaviour
{
    public Sprite enterence_open;

    private SpriteRenderer enterenceSptireRenderer;

    // Start is called before the first frame update
    void Start()
    {
        enterenceSptireRenderer = GetComponent<SpriteRenderer>();
        
    }

    public void EnterenceOpen()
    {
        Debug.Log("work");
        enterenceSptireRenderer.sprite = enterence_open;
    }
}
