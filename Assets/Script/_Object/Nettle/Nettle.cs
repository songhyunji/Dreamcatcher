using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory invenScript;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			if(playerScript.hasKey==true)
			{
				invenScript.SaveItem(0);
				playerScript.hasKey = false;
				Destroy(this.gameObject);
			}
		}
	}
}
