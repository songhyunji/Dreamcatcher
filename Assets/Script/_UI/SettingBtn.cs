using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingBtn : MonoBehaviour {

	public GameObject settingPanel;
	public GameObject errorPopupCat;
	public GameObject errorPopupDog;
	public GameObject player;

	public void SettingBtnPress()
	{
		settingPanel.SetActive(true);
	}

	public void HomeBtnPress()
	{
		GameObject newGO = new GameObject();
		player.transform.parent = newGO.transform; // NO longer DontDestroyOnLoad();
		transform.SetParent(null);
		SceneManager.LoadScene("Main");
	}

	public void CatBtnPress()
	{
		errorPopupCat.SetActive(true);
	}

	public void DogBtnPress()
	{
		errorPopupDog.SetActive(true);
	}

	public void ExitPopupCat()
	{
		errorPopupCat.SetActive(false);
	}

	public void ExitPopupDog()
	{
		errorPopupDog.SetActive(false);
	}

	public void ExitSettingPanel()
	{
		settingPanel.SetActive(false);
	}
}
