using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSceneLoad : MonoBehaviour
{

	public Apple appleScript;

	void Start ()
	{
		appleScript.player = GameObject.Find("TestPlayer");
		
	}
}
