using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public Rune runeScript;
	public float speed = 0.01f;

	public string saveName;

	private void Start()
	{
		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}
	private void FixedUpdate()
	{
		if(runeScript.RuneSwitch==false)
		{
			if(transform.position.y<5.48)
			{
				transform.Translate(0, speed, 0);
			}
			else
			{
				SaveData();
			}

		}
	}

	public void SaveData()
	{
		var pos = this.transform.position;

		var posString = "";

		posString += pos.x + "," + pos.y;

		PlayerPrefs.SetString(saveName, posString);
	}

	public void LoadData()
	{
		var posData = PlayerPrefs.GetString(saveName).Split(',');

		var loadedPos = new Vector3(float.Parse(posData[0]), float.Parse(posData[1]), 0);

		this.transform.position = loadedPos;
	}
}
