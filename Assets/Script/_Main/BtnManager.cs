using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

	public GameObject errorLoadPopup;
	public GameObject OptionPopup;
    public GameObject player;
	[HideInInspector]
	public GameObject player_object;
	private float playerposX;
    private float playerposY;
    private string loadSceneName = "";


    private void Start()
    {

    }

    public void StartBtnPress()
	{
		CreatePlayer(new Vector3(-2.11f, -1.5f));
		SceneManager.LoadScene("A0");
        //player.transform.position = new Vector3(-2.11f, -1.5f);
        PlayerPrefs.DeleteAll();

        
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
        

    }

	public void LoadBtnPress()
	{

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
            //player.transform.position = new Vector3(playerposX, playerposY);
        }
    }

	public void OptionBtnPress()
	{
		OptionPopup.SetActive(true);
	}

    public void ExitBtnPress()
    {
        Application.Quit();
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

}
