using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public bool isOn;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			isOn = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") || collision.CompareTag("Foothold"))
		{
			isOn = false;
		}
	}
}
