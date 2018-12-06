using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSceneLoad : MonoBehaviour
{

	public SpawnButton spawnBtnScript;
	public JumpButton jumpBtnScript;

	void Start ()
	{
		jumpBtnScript.playerScript=GameObject.Find("TestPlayer").GetComponent<Player_subslope>();
		
		spawnBtnScript.player = GameObject.Find("TestPlayer");
		spawnBtnScript.playerScript = GameObject.Find("TestPlayer").GetComponent<Player_subslope>();

	}
}
