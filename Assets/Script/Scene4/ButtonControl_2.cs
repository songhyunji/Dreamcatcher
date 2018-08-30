using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl_2 : MonoBehaviour
{

	public GameObject interactBtn;


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			interactBtn.GetComponent<Button>().enabled = true;
		}
	}
	
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			interactBtn.GetComponent<Button>().enabled = false;
		}
	}
}
