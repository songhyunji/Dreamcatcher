using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderSceneLoad : MonoBehaviour
{

	public Ladder_test ladderScript;

	void Start ()
	{
		ladderScript.player = GameObject.Find("TestPlayer");
		ladderScript.playerScript = GameObject.Find("TestPlayer").GetComponent<Player_subslope>();

	}
}
