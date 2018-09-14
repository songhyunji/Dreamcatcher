using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
	public float dir;
	public Vector2 startPos;			
	public Vector2 direction;

	Controller2D controller;
	
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

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
	}

	void Update() {

		if (controller.collisions.above || controller.collisions.below) {
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
							dir = 1;
						}
						else if (direction.x < 0)
						{
							dir = -1;
						}

						break;

					case TouchPhase.Ended:
						dir = 0;
						break;
				}
			}
			else
			{
				dir = 0;
			}
		}
		
		Vector2 input = new Vector2(dir, Input.GetAxisRaw("Vertical"));
		//print(input.x);
		

		if (isJumping)
		{
			velocity.y = jumpVelocity;
			isJumping = false;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelerationTimeGrounded:accelerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}

	public void PressJumpBtn()
	{
		if (controller.collisions.below)
		{
			isJumping = true;
		}
		else
		{
			isJumping = false;
		}
	}

}
