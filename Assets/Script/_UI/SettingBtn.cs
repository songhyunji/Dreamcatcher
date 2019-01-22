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

    private List<GameObject> footholds = new List<GameObject>();

    void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
        var foothold = GameObject.FindGameObjectsWithTag("Foothold");
        foreach(var c in foothold)
        {
            footholds.Add(c);
        }
    }

    public void SettingBtnPress()
	{
		settingPanel.SetActive(true);
	}

	public void HomeBtnPress()
	{
		Destroy(player);
        RemoveObject();
		SceneManager.LoadScene("Main");
	}

	public void CatBtnPress()
	{
		errorPopupCat.SetActive(true);
	}

	public void RestartBtnPress()
	{
        RestartSceneFunc();
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

    private void RestartSceneFunc()
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
            RemoveObject();

            SceneManager.LoadScene(loadSceneName);
            player.transform.position = new Vector3(playerposX, playerposY);
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
}
