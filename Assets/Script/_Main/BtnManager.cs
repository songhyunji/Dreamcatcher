using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

	public GameObject errorLoadPopup;
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

	private AudioSource _audioSource;

	private void Start()
    {
		_audioSource = GetComponent<AudioSource>();
		img = fade.GetComponent<Image>();
		StartCoroutine(FadeImage(true, 0));
	}

    public void StartBtnPress()
	{
		_audioSource.Play();
		StartCoroutine(FadeImage(false, 1));
	}

	public void LoadBtnPress()
	{
		_audioSource.Play();
		loadSceneName = PlayerPrefs.GetString("SaveStage");
		if (loadSceneName.Length == 0) // 저장된 데이터가 없을 때
		{
			Debug.Log("No data");
			errorLoadPopup.SetActive(true);
		}
		else
		{
			StartCoroutine(FadeImage(false, 2));
		}

    }

	public void ExitLoadPopup()
	{
		_audioSource.Play();
		errorLoadPopup.SetActive(false);
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
					SceneManager.LoadScene("Prologue");


					break;
				case 2: // load game
					playerposX = PlayerPrefs.GetFloat("posX");
					playerposY = PlayerPrefs.GetFloat("posY");
					loadSceneName = PlayerPrefs.GetString("SaveStage");

					CreatePlayer(new Vector3(playerposX, playerposY));
					SceneManager.LoadScene(loadSceneName);
					break;
				default:
					break;
			}
		}
	}

}
