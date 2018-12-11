using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingBtnSceneLoad : MonoBehaviour {

	public SettingBtn settingBtnScript;

	void Start()
	{
		settingBtnScript.player = GameObject.Find("TestPlayer");

	}
}
