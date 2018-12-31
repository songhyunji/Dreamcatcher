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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
