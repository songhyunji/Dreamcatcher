using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flytrap : MonoBehaviour
{
    public bool canEat = true;
    public GameObject player;

	private float playerposX;
	private float playerposY;
	private string loadSceneName = "";

	private void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
    }

    private void FixedUpdate()
    {
        if(!canEat)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if(canEat)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        }
    }

    private void Eat()
    {
		playerposX = PlayerPrefs.GetFloat("posX");
		playerposY = PlayerPrefs.GetFloat("posY");
		loadSceneName = PlayerPrefs.GetString("SaveStage");

		player.transform.position = new Vector3(playerposX, playerposY);
		SceneManager.LoadScene(loadSceneName);

	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&canEat)
        {
            Debug.Log("Eat");
            canEat = false;
            Eat();
        }
    }
    
}
