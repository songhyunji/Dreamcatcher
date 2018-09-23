using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;
	float moveSpeed = 6;

	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	private bool isJumping = false;
	private bool isGround = false;
	public float dir;
	public Vector2 startPos;			
	public Vector2 direction;

	private Controller2D controller;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	
	void Awake () 
	{
		
		DontDestroyOnLoad(this);
		
		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	void Start() {
		
		controller = GetComponent<Controller2D> ();
        animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void FixedUpdate()
	{

		if (controller.collisions.above || controller.collisions.below)
		{
			velocity.y = 0;
		}

		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);

			if (touch.position.x <= Screen.width / 2)
			{
				switch (touch.phase)
				{
					case TouchPhase.Began:
						startPos = touch.position;
						break;

					case TouchPhase.Moved:
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

						break;

					case TouchPhase.Ended:
						animator.SetBool("isWalking", false);
						dir = 0;
						break;
				}
			}
			else
			{
				dir = 0;
				animator.SetBool("isWalking", false);
			}
		}

		Vector2 input = new Vector2(dir, Input.GetAxisRaw("Vertical"));
		//print(input.x);
		
		//Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


		if (isJumping)
		{
			velocity.y = jumpVelocity;
			isJumping = false;
			isGround = false;
			
			animator.SetBool(("isJumping"), true);
		}
		
		
		
		if (isGround)
		{
			animator.SetBool(("isJumping"), false);
		}
		
		
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing,
			(controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);

		/*if (Input.GetAxisRaw("Horizontal") != 0)
		{
			animator.SetBool("isWalking", true);
		}
		else
		{
			animator.SetBool("isWalking", false);
		}*/

		
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.contacts[0].normal.y > 0.9f)
		{
			isGround = true;
			Debug.Log("착지");
		}
	}


	public void Jump()
	{
		if (controller.collisions.below)
		{
			isJumping = true;
            animator.SetBool("isJumping", true);
        }
        
	}
}
