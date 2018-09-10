using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	public float speed;
	public float jumpForce;
	public GameObject speechBubble;
	public Vector2 startPos;			
	public Vector2 direction;
	
	private bool isGround = true;
	private Rigidbody2D rd2D;
	private Transform transform;
	private bool isMoving = false;
	private float dir;
	
	void Start ()
	{

		rd2D = GetComponent<Rigidbody2D>();
		transform = GetComponent<Transform>();
	}

	private void Update()
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
						isMoving = true;
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
						isMoving = false;
						break;
				}
			}
			else
			{
				isMoving = false;
			}
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

	private void FixedUpdate()
	{
		if (isMoving)
		{
			rd2D.AddForce(dir * transform.right * speed * Time.deltaTime);
		}
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
		if (speechBubble.activeSelf == true)
		{
			speechBubble.SetActive(false);
		}
		else if (speechBubble.activeSelf == false)
		{
			speechBubble.SetActive(true);
		}
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.contacts[0].normal.y>0.9f)
		{

			if (other.collider.CompareTag("Ground"))
			{
				isGround = true;
			}

		}

	}
}
