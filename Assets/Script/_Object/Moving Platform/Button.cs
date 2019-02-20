using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public Sprite btnOff;
	public Sprite btnOn;
	public bool isOn;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			isOn = true;
			GetComponent<SpriteRenderer>().sprite = btnOn;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			isOn = false;
			GetComponent<SpriteRenderer>().sprite = btnOff;
		}
	}
}
