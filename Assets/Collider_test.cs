using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_test : MonoBehaviour
{
	public Player_subslope playerScript;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			playerScript.isGround = true;
			Debug.Log("is Ground true");
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			playerScript.isGround = false;
			Debug.Log("is Ground false");
		}
	}
}