using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
	
	public GameObject player;
	private Rigidbody2D rb2D;
	private Transform pos;

	public bool isTouch;
	public bool isAttatch;
	public int playerPosX = 35;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		pos = player.GetComponent<Transform>();
		rb2D.gravityScale = 0;
		rb2D.isKinematic = false;
	}

	private void FixedUpdate()
	{
		
		if (pos.position.x >= playerPosX)
		{
			rb2D.gravityScale = 1;
		}

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = true;
		}

		if (other.collider.CompareTag("Ground"))
		{
			Debug.Log("땅에 닿음");
		}
		
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = false;
		}
	}
	
	public void PressInteractBtn()
	{
		if (isTouch&&!isAttatch)
		{
			transform.SetParent(player.transform);
			transform.Translate(0, 0.5f, 0);
			rb2D.isKinematic = true;
			isAttatch = true;
		}
		else if(isAttatch)
		{
			transform.SetParent(null);
			rb2D.isKinematic = false;
			isAttatch = false;
		}
	}
}
