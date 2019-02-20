using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_Key : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory invenScript;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			playerScript.hasKey = true;
			invenScript.SaveItem(1);
			Destroy(this.gameObject);
		}
	}

}
