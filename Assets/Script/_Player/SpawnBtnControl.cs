using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBtnControl : MonoBehaviour
{
	public GameObject spawnBtn;
	private int meetWolf; // 1 == true, 0 == false;

	private void Update()
	{
		meetWolf = PlayerPrefs.GetInt("wolf");
		if (meetWolf == 1)
		{
			spawnBtn.SetActive(true);
		}
		else
		{
			spawnBtn.SetActive(false);
		}
	}
}
