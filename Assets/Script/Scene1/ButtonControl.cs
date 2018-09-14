using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ButtonControl : MonoBehaviour
{

	public GameObject jumpBtn;
	public GameObject interactBtn;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			interactBtn.SetActive(true);
			jumpBtn.SetActive(false);
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			interactBtn.SetActive(false);
			jumpBtn.SetActive(true);
		}
	}
}
