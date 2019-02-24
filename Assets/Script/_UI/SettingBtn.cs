﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{

	public GameObject settingPanel;
	public GameObject errorRestartPopup;
	public GameObject player;

	public Image img;
	public Image fadeImg;

	private float playerposX;
	private float playerposY;
	private string loadSceneName = "";
	private int dieRestart; // 0 == false, 1 == true
	public float fadeSpeed = 0.01f;

	public FadeScene fadeSceneScript;

	void Start()
	{
		player = GameObject.Find("TestPlayer(Clone)");
	}

	public void SettingBtnPress()
	{
		Time.timeScale = 0;
		settingPanel.SetActive(true);
	}

	public void HomeBtnPress()
	{
		fadeSceneScript.HomeBtnPress();

	}

	public void RestartBtnPress()
	{
		Time.timeScale = 1;
		RestartSceneFunc();
	}
	public void ExiterrorRestartPopup()
	{
		errorRestartPopup.SetActive(false);
	}

	public void ExitSettingPanel()
	{
		Time.timeScale = 1;
		settingPanel.SetActive(false);
	}

	private void RestartSceneFunc()
	{
		fadeSceneScript.RestartSceneFunc();
	}
}
