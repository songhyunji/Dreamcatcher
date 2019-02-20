using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
	public GameObject stagePanel;
	public GameObject player;
	public GameObject inventory;
	[HideInInspector]
	public GameObject player_object;

	public void StageSelectBtnPress()
	{
		stagePanel.SetActive(true);
	}

	public void ExitBtnPress()
	{
		stagePanel.SetActive(false);
	}

	public void StageA0BtnPress()
	{
		CreatePlayer(new Vector3(-2.11f, -1.5f));

		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", -2.11f);
		PlayerPrefs.SetFloat("posY", -1.5f);
		PlayerPrefs.SetString("SaveStage", "A0");
		Debug.Log("저장");

		SceneManager.LoadScene("A0");
	}

	public void StageA1BtnPress()
	{
		CreatePlayer(new Vector3(40, 4));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 40);
		PlayerPrefs.SetFloat("posY", 4);
		PlayerPrefs.SetString("SaveStage", "A1");
		Debug.Log("저장");

		SceneManager.LoadScene("A1");
	}

	public void StageA2BtnPress()
	{
		CreatePlayer(new Vector3(64, 3));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 64);
		PlayerPrefs.SetFloat("posY", 3);
		PlayerPrefs.SetString("SaveStage", "A2");
		Debug.Log("저장");

		SceneManager.LoadScene("A2");
	}

	public void StageB1BtnPress()
	{
		CreatePlayer(new Vector3(51, -1));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 51);
		PlayerPrefs.SetFloat("posY", -1);
		PlayerPrefs.SetString("SaveStage", "B1");
		Debug.Log("저장");

		SceneManager.LoadScene("B1");
	}

	public void StageB2BtnPress()
	{
		CreatePlayer(new Vector3(98, 1));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 98);
		PlayerPrefs.SetFloat("posY", 1);
		PlayerPrefs.SetString("SaveStage", "B2");
		Debug.Log("저장");

		SceneManager.LoadScene("B2");
	}

	public void StageB3BtnPress()
	{
		CreatePlayer(new Vector3(161, 3));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 161);
		PlayerPrefs.SetFloat("posY", 3);
		PlayerPrefs.SetString("SaveStage", "B3");
		Debug.Log("저장");

		SceneManager.LoadScene("B3");
	}

	public void StageB4BtnPress()
	{
		CreatePlayer(new Vector3(160, 15));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 160);
		PlayerPrefs.SetFloat("posY", 15);
		PlayerPrefs.SetString("SaveStage", "B4");
		Debug.Log("저장");

		SceneManager.LoadScene("B4");
	}

	public void StageB5BtnPress()
	{
		CreatePlayer(new Vector3(200, 2.3f));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 200);
		PlayerPrefs.SetFloat("posY", 2.3f);
		PlayerPrefs.SetString("SaveStage", "B5");
		Debug.Log("저장");

		SceneManager.LoadScene("B5");
	}

	public void StageB6BtnPress()
	{
		CreatePlayer(new Vector3(123, 15));
		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", 123);
		PlayerPrefs.SetFloat("posY", 15);
		PlayerPrefs.SetString("SaveStage", "B6");
		Debug.Log("저장");

		SceneManager.LoadScene("B6");
	}

	public void CreatePlayer(Vector3 playerPosition)
	{
		player_object = Instantiate(player, playerPosition, Quaternion.identity);
	}
}
