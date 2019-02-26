using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseRuneSound : MonoBehaviour
{
	private AudioSource _audioSource;
	public Rune runeScript;

    // Start is called before the first frame update
    void Start()
    {
		_audioSource = GetComponent<AudioSource>();
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
			}
		}
	}
}
