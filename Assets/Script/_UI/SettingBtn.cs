using System.Collections;
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

	private void Awake()
	{
		dieRestart = PlayerPrefs.GetInt("dieRestart");
		if(dieRestart==1)
		{
			fadeImg.gameObject.SetActive(true);
			PlayerPrefs.SetInt("dieRestart", 0); //0 == false,1 == true
			StartCoroutine(DieFade());
		}
		else
		{
			StartCoroutine(FadeImage(true, 0));
		}
	}

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
		Time.timeScale = 1;
		StartCoroutine(FadeImage(false, 1));

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
		player.GetComponent<Player_subslope>().hasKey = false;
		playerposX = PlayerPrefs.GetFloat("posX");
		playerposY = PlayerPrefs.GetFloat("posY");
		loadSceneName = PlayerPrefs.GetString("SaveStage");

		if (loadSceneName.Length == 0)
		{
			errorRestartPopup.SetActive(true);
		}
		else
		{
			img.gameObject.SetActive(true);
			StartCoroutine(FadeImage(false, 2));

		}
	}

	IEnumerator FadeImage(bool fadeAway,int num)
	{
		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}

			switch(num)
			{
				case 0:
					Time.timeScale = 1;
					img.gameObject.SetActive(false);
					break;
				default:
					break;

			}


		}
		else
		{
			img.gameObject.SetActive(true);
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}
			
			switch(num)
			{
				case 1:
					Debug.Log("home btn");
					Destroy(player);
					Destroy(GameObject.Find("Inventory(Clone)"));
					SceneManager.LoadScene("Main");
					break;
				case 2:
					Debug.Log("restart btn");
					player.transform.position = new Vector3(playerposX, playerposY);
					SceneManager.LoadScene(loadSceneName);
					break;
				default:
					break;
			}				

		}
	}

	IEnumerator DieFade()
	{
		for (float i = 1; i >= -1; i -= 0.1f)
		{
			fadeImg.color = new Color(0.6509f, 0.0627f, 0.1176f, i);
			yield return null;
		}
		fadeImg.gameObject.SetActive(false);
	}

}
