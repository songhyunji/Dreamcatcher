using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class LoadScene_drop : MonoBehaviour {

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
			Time.timeScale = 0;
			player.transform.position = new Vector2(120, 9);
			img.gameObject.SetActive(true);
			StartCoroutine(FadeImage(false));
            //Debug.Log("Touch Load Scene Collider");
            /*SceneManager.LoadScene(sceneName + sceneNum);

            PlayerPrefs.SetFloat("posX", player.transform.position.x);
            PlayerPrefs.SetFloat("posY", player.transform.position.y);
            PlayerPrefs.SetString("SaveStage", sceneName + sceneNum);*/
            //Debug.Log("저장");

            //Debug.Log("posX");
            //Debug.Log(PlayerPrefs.GetFloat("posX"));
            //Debug.Log("posY");
            //Debug.Log(PlayerPrefs.GetFloat("posY"));
            //Debug.Log("Scene Name");
            //Debug.Log(PlayerPrefs.GetString("SaveStage"));


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerScript.SearchObject();
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
			SceneManager.LoadScene(sceneName + sceneNum);

			PlayerPrefs.SetFloat("posX", player.transform.position.x);
			PlayerPrefs.SetFloat("posY", player.transform.position.y);
			PlayerPrefs.SetString("SaveStage", sceneName + sceneNum);
		}
	}
}
