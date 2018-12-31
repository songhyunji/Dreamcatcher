using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    private Text text;
    public SpawnBtnSceneLoad spawnBtn;
    public SpawnButton spawn;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawn.player == null)
        {
            text.text += "\nPlayer Null";
        }
        if(spawn.wolf == null)
        {
            text.text += "\nWolf Null";
        }
        if(spawn.playerScript == null)
        {
            text.text += "\nScirpt Null";
        }
        if(spawnBtn.spawnBtnScript == null)
        {
            text.text += "\nBtn Script Null";
        }
    }
}
