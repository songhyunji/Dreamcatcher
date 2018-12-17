using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBtnSceneLoad : MonoBehaviour
{

	public SpawnButton spawnBtnScript;

	void Start ()
	{
		spawnBtnScript.player = GameObject.Find("TestPlayer");
		spawnBtnScript.playerScript = GameObject.Find("TestPlayer").GetComponent<Player_subslope>();

	}
}
