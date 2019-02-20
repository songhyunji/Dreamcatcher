using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : MonoBehaviour
{
	public GameObject lily;
	public Inventory_test invenScript;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			invenScript.GetLily();
			Destroy(lily);
		}
	}

}
