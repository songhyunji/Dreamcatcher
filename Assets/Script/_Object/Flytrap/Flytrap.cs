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

    IEnumerator CannotEat()
    {
        symbol.SetActive(true);
        canEat = false;
        yield return null;
    }

    IEnumerator CanEat()
    {
        symbol.SetActive(false);
        canEat = true;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&canEat)
        {
            Debug.Log("Eat");
            StartCoroutine("Eat");
        }
        else if (collision.CompareTag("Foothold"))
        {
            Debug.Log("Can not eat");
            StartCoroutine("CannotEat");
        }

    }
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out");
        }
        else if (collision.CompareTag("Foothold"))
        {
            Debug.Log("Can eat");
            StartCoroutine("CanEat");
        }
    }
}
