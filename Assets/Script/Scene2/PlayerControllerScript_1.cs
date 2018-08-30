using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;

public class PlayerControllerScript_1 : MonoBehaviour
{

	public Joystick joystick; // 조이스틱 스크립트
	public float MoveSpeed; // 플레이어 이동속도

	public GameObject speechBubble;

	private bool isGround = true;

	private Vector3 _moveVector; // 플레이어 이동벡터
	private Transform _transform;

	void Start ()
	{

		_transform = transform; // Transform 캐싱
		_moveVector = Vector3.zero; // 플레이어 이동벡터 초기화
	}
	
	void Update () {
		
		// 터치패드 입력 받기
		HandleInput();

	}

	private void FixedUpdate()
	{
		// 플레이어 이동
		Move();
	}

	public void HandleInput()
	{
		_moveVector = PoolInput();
	}

	public Vector3 PoolInput()
	{
		float h = joystick.GetHorizontalValue();
		float v = joystick.GetVerticalValue();
		Vector3 moveDir = new Vector3(h, v, 0).normalized;

		return moveDir;
	}

	public void Move()
	{
		_transform.Translate(_moveVector * MoveSpeed * Time.deltaTime);
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
