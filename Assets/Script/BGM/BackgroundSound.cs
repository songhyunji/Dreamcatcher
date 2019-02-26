using System.Collections;
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
	public AudioClip stageBBGM;
	public AudioClip prologueBGM;


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
			case 0: // main Scene
				_audioSource.clip = mainBGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}

				break;
			case 2: // A0 Scene
			case 3:
			case 4:
				_audioSource.clip = stageABGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				break;
			case 5: // B1 Scene
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
				_audioSource.clip = stageBBGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				break;
			default:
				_audioSource.clip = prologueBGM;
				if (!_audioSource.isPlaying)
				{
					_audioSource.Play();
				}
				break;
		}
	}
}
