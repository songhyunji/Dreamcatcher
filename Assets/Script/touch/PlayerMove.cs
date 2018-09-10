using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public float speed;
	public float speed_up;
	public float jumpForce;
	public GameObject speechBubble;
	public Vector2 startPos;			
	public Vector2 direction;
	
	private bool isGround = true;
	private Rigidbody2D rd2D;
	private Transform transform;
	private bool isMovingHorizental = false;
	private bool isMovingVertical = false;
	private float dir;
	private bool nearFrog = false;
	private bool onLadder = false;
	private bool goUpside = false;
	
	void Start ()
	{
		rd2D = GetComponent<Rigidbody2D>();
		transform = GetComponent<Transform>();
	}

	private void Update()
	{
		if (goUpside)
		{
			rd2D.gravityScale = 0;
			MoveVertical();
			
		}
		else
		{
			rd2D.gravityScale = 2;
			MoveHorizental();
		}
	}

	private void FixedUpdate()
	{
		if (isMovingHorizental)
		{
			rd2D.AddForce(dir * transform.right * speed * Time.deltaTime);
		}
		else if (isMovingVertical)
		{
			rd2D.AddForce(dir * transform.up* speed_up * Time.deltaTime);
		}
		
		/* if(Input.GetKey(KeyCode.D))
			{
				rd2D.AddForce(transform.right * speed * Time.deltaTime);
			}
			else if (Input.GetKey(KeyCode.A))
			{
				rd2D.AddForce(-1 * transform.right * speed * Time.deltaTime);
			} */
	}
	
	public void PressJumpBtn()
	{
		if (isGround)
		{
			isGround = false;
			rd2D.AddForce(transform.up * jumpForce);
		}
	}

	public void PressInteractBtn()
	{
		if (nearFrog)
		{
			if (speechBubble.activeSelf == true)
			{
				speechBubble.SetActive(false);
			}
			else if (speechBubble.activeSelf == false)
			{
				speechBubble.SetActive(true);
			}
		}
		else if (onLadder)
		{
			if (goUpside)
			{
				goUpside = false;
			}
			else if (!goUpside)
			{
				goUpside = true;
			}
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.contacts[0].normal.y > 0.9f)
		{
			isGround = true;
			
			/*if (other.collider.CompareTag("Ground"))
			{
				isGround = true;
			}*/
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Frog"))
		{
			nearFrog = true;
			Debug.Log("Touch Frog");
		}
		else if (other.CompareTag("Ladder"))
		{
			onLadder = true;
			Debug.Log("Touch Ladder");
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Frog"))
		{
			nearFrog = false;
			Debug.Log("Exit Frog");
		}
		else if (other.CompareTag("Ladder"))
		{
			onLadder = false;
			goUpside = false;
			Debug.Log("Exit Ladder");
		}
	}

	public void MoveVertical()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				switch (touch.phase)
				{
					case TouchPhase.Began:
						startPos = touch.position;
						isMovingVertical = true;
						break;

					case TouchPhase.Moved:
						direction = touch.position - startPos;
						if (direction.y > 0)
						{
							dir = 1;
						}
						else if (direction.y < 0)
						{
							dir = -1;
						}

						break;

					case TouchPhase.Ended:
						isMovingVertical = false;
						break;
				}
			}
			else
			{
				isMovingVertical = false;
			}
		}
	}

	public void MoveHorizental()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				switch (touch.phase)
				{
					case TouchPhase.Began:
						startPos = touch.position;
						isMovingHorizental = true;
						break;

					case TouchPhase.Moved:
						direction = touch.position - startPos;
						if (direction.x > 0)
						{
							dir = 1;
						}
						else if (direction.x < 0)
						{
							dir = -1;
						}

						break;

					case TouchPhase.Ended:
						isMovingHorizental = false;
						break;
				}
			}
			else
			{
				isMovingHorizental = false;
			}
		}
	}
}
