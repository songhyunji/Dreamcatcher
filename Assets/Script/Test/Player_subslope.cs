using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using Debug = UnityEngine.Debug;

public class Player_subslope : MonoBehaviour {

	public bool isJumping = false;
	public bool isGround = false;
	public bool onLadder = false;
	public bool exitLadder = true;
	public bool isTouching = false;
	public float dir;
	public float speed;
	public float jumpspeed;
	public Vector2 startPos;			
	public Vector2 direction;

	private SpriteRenderer spriteRenderer;
	private Animator animator;
	private Rigidbody2D rb2D;
	
	
	void Awake () 
	{
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Start() {
		
        animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		rb2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if (onLadder)
		{
			Climb();
		}
		else
		{
			Walk();
		}
		
		if (isGround)
		{
			animator.SetBool(("isJumping"), false);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
     {
     	if (other.collider.CompareTag("Ground") || other.contacts[0].normal.x != 0)
     	{
     		isGround = true;
     		onLadder = false;
     		Debug.Log("착지");
     	}
	    else if (other.collider.CompareTag("Foothold"))
	     {
		     isTouching = true;
		     isJumping = false;
		     animator.SetBool("isJumping",false);
		     Debug.Log("발판 위에 착지");
	     }
     }
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Foothold"))
		{
			isTouching = false;
			animator.SetBool("isJumping",true);
			Debug.Log("공중에 떠있음");
		}
	}

	public void Walk()
	{
		if (Input.touchCount > 0 && !onLadder)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				if (touch.phase == TouchPhase.Began)
				{
					startPos = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					direction = touch.position - startPos;
					if (direction.x > 0)
					{
						animator.SetBool("isWalking", true);
						spriteRenderer.flipX = false;
						dir = 1;

					}
					else if (direction.x < 0)
					{
						animator.SetBool("isWalking", true);
						spriteRenderer.flipX = true;
						dir = -1;
					}
						
					transform.Translate(dir * Vector3.right * speed * Time.deltaTime);
				}
				else if (touch.phase == TouchPhase.Ended)
				{
					animator.SetBool("isWalking", false);
				}
			}
			else
			{
				animator.SetBool("isWalking", false);
			}
		}
		else
		{
			animator.SetBool("isWalking", false);
		}
	}
	
	public void Jump()
	{			
		if (isGround)
		{
			isJumping = true;
            animator.SetBool("isJumping", true);
			isGround = false;
			rb2D.AddForce(Vector3.up * jumpspeed , ForceMode2D.Impulse);
			isJumping = false;
        }
        
	}

	public void Climb()
	{
		if (Input.touchCount > 0 && onLadder)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				if (touch.phase == TouchPhase.Began)
				{
					startPos = touch.position;
				}
				else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					direction = touch.position - startPos;
					if (direction.y > 0)
					{
						//animator.SetBool("isWalking", true);
						//spriteRenderer.flipX = false;
						dir = 1;
						transform.Translate(dir * Vector3.up * speed * Time.deltaTime);
					}
					else if (direction.y < 0)
					{
						//animator.SetBool("isWalking", true);
						//spriteRenderer.flipX = true;
						dir = -1;
						transform.Translate(dir * Vector3.up * speed * Time.deltaTime);
					}

					
					if (exitLadder&&onLadder)
					{
						rb2D.AddForce(Vector2.left * speed * Time.deltaTime);
						onLadder = false;
					}
						

				}
				else if (touch.phase == TouchPhase.Ended)
				{
					//animator.SetBool("isWalking", false);
				}
				
			}
			
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ladder"))
		{
			Debug.Log("사다리 탐");
			Vector3 otherPos = other.GetComponent<Transform>().position;
			transform.position = new Vector3(otherPos.x, transform.position.y, transform.position.z);

			rb2D.gravityScale = 0;
			isJumping = false;
			onLadder = true;
			exitLadder = false;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ladder"))
		{
			rb2D.gravityScale = 1;
			
			onLadder = false;
			exitLadder = true;

		}
	}
}
