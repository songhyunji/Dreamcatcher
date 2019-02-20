using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_Key : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory_test invenScript;

	public string saveName;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			invenScript.GetKey();
			SaveData();
		}
	}

	public void SaveData()
	{
		Destroy(this.gameObject);

		PlayerPrefs.SetString(saveName, "destroy");
	}

	public void LoadData()
	{
		var data = PlayerPrefs.GetString(saveName);

		if (data == "destroy")
		{
			Destroy(this.gameObject);
		}
	}

}
