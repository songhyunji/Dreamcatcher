using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flytrap : MonoBehaviour
{
    public bool canEat = true;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("TestPlayer");
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
        player.transform.position = new Vector2(-2,-3.6f);
        SceneManager.LoadScene(4);
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
