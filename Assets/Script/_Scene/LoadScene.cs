using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public string sceneName;
    public int sceneNum;
    public GameObject player;
    public Player_subslope playerScript;

	public Image img;

	private Vector3 playerPos;

    void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
		{
			PlayerPrefs.Save();
			img.gameObject.SetActive(true);
			playerScript.isSceneLoading = true;
			StartCoroutine(FadeImage(false));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
			playerScript.isSceneLoading = false;
			SceneManager.LoadScene(sceneName + sceneNum);

			PlayerPrefs.SetFloat("posX", player.transform.position.x);
			PlayerPrefs.SetFloat("posY", player.transform.position.y);
			PlayerPrefs.SetString("SaveStage", sceneName + sceneNum);
		}
	}
}
