using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRuneSound : MonoBehaviour
{
	private AudioSource _audioSource;
	public Rune runeScript;

	[SerializeField]
	private GameObject bgm;
	private AudioSource bgmAudioSource;

    // Start is called before the first frame update
    void Start()
    {
		_audioSource = GetComponent<AudioSource>();
		bgm = GameObject.Find("BackgroundSound");
		bgmAudioSource = bgm.GetComponent<AudioSource>();
    }

	private void Update()
	{
		if(!runeScript.RuneSwitch)
		{
			_audioSource.Stop();
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			if (!_audioSource.isPlaying && runeScript.RuneSwitch)
			{
				_audioSource.Play();
				for (float i = 0; i <= 1; i += 0.001f)
				{
					_audioSource.volume = i;
				}
				for (float i = 1; i >= 0; i -= 0.001f)
				{
					bgmAudioSource.volume = i;
				}
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player"))
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
				for (float i = 1; i >= 0; i -= 0.001f)
				{
					_audioSource.volume = i;
				}
				for (float i = 0; i <= 1; i += 0.001f)
				{
					bgmAudioSource.volume = i;
				}
			}
		}
	}
}
