using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_switch_horizontal : MonoBehaviour
{

	public float maxX;
	public float minX;
	public float speed;
	public bool rightleft; // 스위치 눌렀을 때 right, 안 눌렀을 때 left
	public bool leftright; // 스위치 눌렀을 때 left, 안 눌렀을 때 right
	public Button buttonScript;
	public AudioClip moveSound;
	public AudioClip moveEndSound;

	private AudioSource _audioSource;
	[SerializeField]
	private Transform pos;
	[SerializeField]
	private float posX;
	
	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		pos = GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true)
        {
			if(rightleft)
			{
				MoveRight();
			}
			else if(leftright)
			{
				MoveLeft();
			}
			
        }
		else
		{
			if (rightleft)
			{
				MoveLeft();
			}
			else if (leftright)
			{
				MoveRight();
			}
		}

	}

    void MoveRight()
    {
        posX = pos.position.x;
		if (posX < maxX)
		{
			if (!_audioSource.isPlaying)
			{
				_audioSource.clip = moveSound;
				_audioSource.loop = true;
				_audioSource.Play();
			}

			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
		else
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
			}
		}
	}

	void MoveLeft()
	{
		posX = pos.position.x;
		if (posX > minX)
		{
			if (!_audioSource.isPlaying)
			{
				_audioSource.clip = moveSound;
				_audioSource.loop = true;
				_audioSource.Play();
			}

			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
		else
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
			}
		}
	}
}
