using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : MonoBehaviour
{
	public GameObject lily;
	public Inventory invenScript;

	private void Start()
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			invenScript.SaveItem(2);
			Destroy(lily);
		}
	}

}
