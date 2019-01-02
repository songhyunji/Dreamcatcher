using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingBtn : MonoBehaviour {

	public GameObject settingPanel;
	public GameObject errorPopupCat;
	public GameObject errorRestartPopup;
	public GameObject player;

    private float playerposX;
    private float playerposY;
    private string loadSceneName = "";


    void Start()
    {
        player = GameObject.Find("TestPlayer");

    }

    public void SettingBtnPress()
	{
		settingPanel.SetActive(true);
	}

	public void HomeBtnPress()
	{
		/*GameObject newGO = new GameObject();
		player.transform.parent = newGO.transform; // NO longer DontDestroyOnLoad();
		transform.SetParent(null);*/
		SceneManager.LoadScene("Main");
	}

	public void CatBtnPress()
	{
		errorPopupCat.SetActive(true);
	}

	public void RestartBtnPress()
	{
        playerposX = PlayerPrefs.GetFloat("posX");
        playerposY = PlayerPrefs.GetFloat("posY");
        loadSceneName = PlayerPrefs.GetString("SaveStage");

        if (loadSceneName.Length == 0)
        {
            errorRestartPopup.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(loadSceneName);
            player.transform.position = new Vector3(playerposX, playerposY);
        }
    }

	public void ExitPopupCat()
	{
		errorPopupCat.SetActive(false);
	}

	public void ExiterrorRestartPopup()
	{
        errorRestartPopup.SetActive(false);
	}

	public void ExitSettingPanel()
	{
		settingPanel.SetActive(false);
	}
}
