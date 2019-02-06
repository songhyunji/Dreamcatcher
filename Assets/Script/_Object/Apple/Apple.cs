﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour {
	
	public GameObject player;
    public GameObject spawnBtn;
    public Player_subslope playerScript;

    private Rigidbody2D rb2D;
	private Transform pos;
    private Collider2D playerCollider;

	public bool isTouch;
    public bool isAttatch;
    public bool isGround;
	public float playerPosX = 35;
    public float boundX;
	

	private void Start()
	{
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
        playerCollider = player.GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
		pos = player.GetComponent<Transform>();
		rb2D.gravityScale = 0;

	}

	private void FixedUpdate()
	{
		
		if (pos.position.x >= playerPosX && !isGround)
		{
			rb2D.gravityScale = 1;
            isGround = true;
		}

        if(isAttatch)
        {
            if(playerScript.isLeft)
            {
                transform.position = new Vector2(playerCollider.bounds.center.x - boundX, playerCollider.bounds.center.y + 0.3f);
            }
            else
            {
                transform.position = new Vector2(playerCollider.bounds.center.x + boundX, playerCollider.bounds.center.y + 0.3f);
            }
            
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
            //jumpBtn = GameObject.Find("JumpBtn");
            //jumpBtn.GetComponent<JumpButton>().enabled = false;

			if (spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = false;
			}

			transform.Translate(0, playerCollider.bounds.center.y - transform.position.y + 0.3f, 0);

            rb2D.gravityScale = 0;
            isAttatch = true;
            
        }
		else if(isAttatch)
		{
            //jumpBtn.GetComponent<JumpButton>().enabled = true;
			if (spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = true;
			}

			rb2D.gravityScale = 1;
			isAttatch = false;
		}
	}
}
