using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public Sprite btnOff;
	public Sprite btnOn;
	public bool isOn;

	private AudioSource _audioSource;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			_audioSource.Play();
			GetComponent<SpriteRenderer>().sprite = btnOn;
			StartCoroutine(WaitForSeconds(1, true));
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			GetComponent<SpriteRenderer>().sprite = btnOff;
			StartCoroutine(WaitForSeconds(1, false));
		}
	}

	IEnumerator WaitForSeconds(int i, bool b)
	{
		yield return new WaitForSeconds(i);
		isOn = b;
	}
}
