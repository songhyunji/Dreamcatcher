using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_Key : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory_test invenScript;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		invenScript = GameObject.Find("Inventory").GetComponent<Inventory_test>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			playerScript.hasKey = true;
			invenScript.GetKey();
			Destroy(this.gameObject);
		}
	}

}
