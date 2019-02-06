﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSound : MonoBehaviour
{
	private AudioSource _audioSource;
	[SerializeField]
	int y;

	public AudioClip mainBGM;
	public AudioClip stageABGM;
	

	void Awake()
	{
		DontDestroyOnLoad(this);

		if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();

		_audioSource.Play();
	}

	private void Update()
	{
		y = SceneManager.GetActiveScene().buildIndex;

		switch (y)
		{
			case 0:
				_audioSource.clip = mainBGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}

				break;
			default:
				_audioSource.clip = stageABGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				break;

				/*case 1:
					_audioSource.clip = stageABGM;
					if (!_audioSource.isPlaying)
					{
						_audioSource.Play();
					}
					break;
					*/
		}
	}
}
