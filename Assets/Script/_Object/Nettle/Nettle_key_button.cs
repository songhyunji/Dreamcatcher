using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_key_button : MonoBehaviour
{
    public Button buttonScript;

	private Rigidbody2D rb2D;
	private BoxCollider2D collider2D;
	private bool isGround = false;
	
	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		collider2D = GetComponent<BoxCollider2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true && !isGround)
        {
			rb2D.gravityScale = 1;
        }
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
		{
			isGround = true;
			rb2D.gravityScale = 0;
			collider2D.isTrigger = true;
			collider2D.usedByEffector = false;
		}
	}
}
