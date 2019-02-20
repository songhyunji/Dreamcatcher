using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory_test invenScript;

	private int hasKey;

	public string saveName;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			hasKey = PlayerPrefs.GetInt("hasKey");
			if(hasKey == 1)
			{
				invenScript.UseKey();
				SaveData();
			}
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
