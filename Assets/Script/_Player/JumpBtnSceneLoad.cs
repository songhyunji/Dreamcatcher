using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBtnSceneLoad : MonoBehaviour
{
	public JumpButton jumpBtnScript;

	void Start ()
	{
		jumpBtnScript.playerScript=GameObject.Find("TestPlayer").GetComponent<Player_subslope>();
		
	}
}
