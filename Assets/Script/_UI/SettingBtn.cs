using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingBtn : MonoBehaviour
{
	public AudioClip touchSound;
	public AudioClip buttonSound;
	private AudioSource _audioSource;

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
		_audioSource = GetComponent<AudioSource>();
	}

	public void SettingBtnPress()
	{
		AudioListener.pause = true;
		Time.timeScale = 0;
		settingPanel.SetActive(true);
	}

	public void HomeBtnPress()
	{
		AudioListener.pause = false;
		Time.timeScale = 1;
		_audioSource.clip = touchSound;
		_audioSource.Play();
		fadeSceneScript.HomeBtnPress();
	}

	public void RestartBtnPress()
	{
		AudioListener.pause = false;
		Time.timeScale = 1;
		_audioSource.clip = touchSound;
		_audioSource.Play();
		RestartSceneFunc();
	}
	public void ExiterrorRestartPopup()
	{
		errorRestartPopup.SetActive(false);
	}

	public void ExitSettingPanel()
	{
		AudioListener.pause = false;
		Time.timeScale = 1;
		_audioSource.clip = buttonSound;
		_audioSource.Play();
		settingPanel.SetActive(false);
	}

	private void RestartSceneFunc()
	{
		fadeSceneScript.RestartSceneFunc();
	}
}
