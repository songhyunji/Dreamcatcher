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

	private float playerposX;
	private float playerposY;
	private string loadSceneName = "";

	private List<GameObject> footholds = new List<GameObject>();

	private void Awake()
	{
		StartCoroutine(FadeImage(true, 0));
	}

	void Start()
	{
		player = GameObject.Find("TestPlayer(Clone)");
		var foothold = GameObject.FindGameObjectsWithTag("Foothold");
		foreach (var c in foothold)
		{
			footholds.Add(c);
		}
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

	private void RemoveObject()
	{
		GameObject newGO = new GameObject();

		for (int i = 0; i < footholds.Count; i++)
		{
			footholds[i].transform.parent = newGO.transform; // NO longer DontDestroyOnLoad();
			transform.SetParent(null);
			Destroy(newGO);
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
					//RemoveObject();
					SceneManager.LoadScene("Main");
					break;
				case 2:
					Debug.Log("restart btn");
					player.transform.position = new Vector3(playerposX, playerposY);
					//RemoveObject();
					SceneManager.LoadScene(loadSceneName);
					break;
				default:
					break;
			}				

		}
	}

}
