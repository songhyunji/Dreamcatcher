using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Apple : MonoBehaviour {

	public GameObject player;
	private Rigidbody2D rb2D;
	private Transform pos;

	public bool isTouch;
	public bool isAttatch;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
		pos = player.GetComponent<Transform>();
		rb2D.gravityScale = 0;
	}

	private void Update()
	{
		if (pos.position.x >= 35)
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
			rb2D.gravityScale = 0;
			isAttatch = true;
		}
		else if(isAttatch)
		{
			transform.SetParent(null);
			rb2D.gravityScale = 1;
			isTouch = false;
			isAttatch = false;
		}
	}
}
