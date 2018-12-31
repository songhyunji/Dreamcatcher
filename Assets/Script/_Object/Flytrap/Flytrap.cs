using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flytrap : MonoBehaviour
{
    public bool canEat = true;
    public GameObject symbol;
    public GameObject player;

    IEnumerator Eat()
    {        
        yield return new WaitForSeconds(5);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        player.transform.position = new Vector2(-2,-3.6f);
        SceneManager.LoadScene(4);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&canEat)
        {
            Debug.Log("Eat");
            canEat = false;
            StartCoroutine("Eat");
        }
        else if (collision.CompareTag("Foothold"))
        {
            symbol.SetActive(true);
            canEat = false;
            StartCoroutine("CannotEat");
        }

    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out");
            canEat = true;
            StopCoroutine("Eat");
        }
        else if (collision.CompareTag("Foothold"))
        {
            symbol.SetActive(false);
            canEat = true;
            StartCoroutine("CanEat");
        }
    }
}
