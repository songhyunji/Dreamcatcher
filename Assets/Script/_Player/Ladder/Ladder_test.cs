using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder_test : MonoBehaviour
{
    public Player_subslope playerScript;

    private Rigidbody2D rb2D;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
        rb2D = player.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            Debug.Log("사다리 탐");
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            Vector3 otherPos = other.GetComponent<Transform>().position;
            playerScript.transform.position = new Vector3(otherPos.x, transform.position.y, transform.position.z);
            rb2D.gravityScale = 0;
            playerScript.isJumping = false;
            playerScript.isGround = false;
            playerScript.onLadder = true;
            playerScript.testCollider.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            rb2D.gravityScale = 5;
            playerScript.onLadder = false;
            playerScript.testCollider.SetActive(true);

        }
    }
}
