using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

	public GameObject errorLoadPopup;
	public GameObject OptionPopup;
    public GameObject player;
	public GameObject inventory;
	[HideInInspector]
	public GameObject player_object;
	private float playerposX;
    private float playerposY;
    private string loadSceneName = "";

	public Canvas canvas;
	public GameObject fade;
	private Image img;

	private void Start()
    {
		img = fade.GetComponent<Image>();
		StartCoroutine(FadeImage(true, 0));
	}

    public void StartBtnPress()
	{
		StartCoroutine(FadeImage(false, 1));
	}

	public void LoadBtnPress()
	{
		StartCoroutine(FadeImage(false, 2));
    }

	public void OptionBtnPress()
	{
		OptionPopup.SetActive(true);
	}

	public void ExitLoadPopup()
	{
		errorLoadPopup.SetActive(false);
	}

	public void ExitOptionPopup()
	{
        OptionPopup.SetActive(false);
	}

	public void CreatePlayer(Vector3 playerPosition)
	{
		player_object = Instantiate(player, playerPosition, Quaternion.identity);
	}

	IEnumerator FadeImage(bool fadeAway, int caseNum)
	{
		fade.SetActive(true);

		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}

			switch (caseNum)
			{
				case 0:
					fade.SetActive(false);
					break;
				default:
					break;
			}
		}
		else
		{
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			switch (caseNum)
			{
				case 1: // start game
					CreatePlayer(new Vector3(-2.11f, -1.5f));

					PlayerPrefs.DeleteAll();

					PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
					PlayerPrefs.SetFloat("posX", -2.11f);
					PlayerPrefs.SetFloat("posY", -1.5f);
					PlayerPrefs.SetString("SaveStage", "A0");
					Debug.Log("저장");

					Debug.Log("posX");
					Debug.Log(PlayerPrefs.GetFloat("posX"));
					Debug.Log("posY");
					Debug.Log(PlayerPrefs.GetFloat("posY"));
					Debug.Log("Scene Name");
					Debug.Log(PlayerPrefs.GetString("SaveStage"));

					SceneManager.LoadScene("A0");
					break;
				case 2: // load game
					playerposX = PlayerPrefs.GetFloat("posX");
					playerposY = PlayerPrefs.GetFloat("posY");
					loadSceneName = PlayerPrefs.GetString("SaveStage");

					if (loadSceneName.Length == 0)
					{
						errorLoadPopup.SetActive(true);
					}
					else
					{
						CreatePlayer(new Vector3(playerposX, playerposY));
						SceneManager.LoadScene(loadSceneName);
					}
					break;
				default:
					break;
			}
		}
	}

}
