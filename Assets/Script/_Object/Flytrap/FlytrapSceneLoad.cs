using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlytrapSceneLoad : MonoBehaviour
{

	public Flytrap FlytrapScript;

	void Start ()
	{
		FlytrapScript.player = GameObject.Find("TestPlayer");
		
	}
}
