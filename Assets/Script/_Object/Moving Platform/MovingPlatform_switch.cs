using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_switch : MonoBehaviour
{

	public float maxY;
	public float minY;
	public float speed;
	public bool updown; // 스위치 눌렀을 때 up, 안 눌렀을 때 down
	public bool downup; // 스위치 눌렀을 때 down, 안 눌렀을 때 up
	public Button buttonScript;
	public AudioClip moveSound;
	public AudioClip moveEndSound;

	private AudioSource _audioSource;
	private Transform pos;
	[SerializeField]
	private float posY;
	
	private void Start()
	{
		pos = GetComponent<Transform>();
		_audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true)
        {
			if(updown)
			{
				MoveUp();
			}
			else if(downup)
			{
				MoveDown();
			}
			
        }
		else
		{
			if (updown)
			{
				MoveDown();
			}
			else if (downup)
			{
				MoveUp();
			}
		}

	}

    void MoveUp()
    {
		posY = pos.position.y;
		if (posY < maxY)
		{
			if (!_audioSource.isPlaying)
			{
				_audioSource.clip = moveSound;
				_audioSource.loop = true;
				_audioSource.Play();
			}

			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
		else
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
			}
		}
    }

	void MoveDown()
	{
		posY = pos.position.y;
		if (posY > minY)
		{
			if (!_audioSource.isPlaying)
			{
				_audioSource.clip = moveSound;
				_audioSource.loop = true;
				_audioSource.Play();
			}

			transform.Translate(Vector3.down * speed * Time.deltaTime);
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
