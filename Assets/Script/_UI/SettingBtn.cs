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
		Destroy(player);
		//RemoveObject();
		SceneManager.LoadScene("Main");
	}

	public void RestartBtnPress()
	{
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
			//RemoveObject();
			StartCoroutine(FadeImage(false));
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

	IEnumerator FadeImage(bool fadeAway)
	{
		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(1, 1, 1, i);
				yield return null;
			}

		}
		else
		{
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}
			player.transform.position = new Vector3(playerposX, playerposY);
			SceneManager.LoadScene(loadSceneName);
		}
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		img.gameObject.SetActive(false);
	}

}
