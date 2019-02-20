using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : MonoBehaviour
{
	public GameObject lily;
	public Inventory_test invenScript;

	public string saveName;

	void Start()
	{
		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			invenScript.GetLily();
			SaveData();
			Destroy(lily);
		}
	}

	public void SaveData()
	{
		Destroy(lily);

		PlayerPrefs.SetString(saveName, "destroy");
	}

	public void LoadData()
	{
		var data = PlayerPrefs.GetString(saveName);

		if (data == "destroy")
		{
			Destroy(lily);
		}
	}

}
