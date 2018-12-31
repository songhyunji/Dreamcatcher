using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour {

	public GameObject errorPopupStageB;
	public GameObject errorPopupStageC;


	public void StartBtnPress()
	{
		SceneManager.LoadScene("A0");
	}

	public void StageBBtnPress()
	{
		errorPopupStageB.SetActive(true);
	}

	public void StageCBtnPress()
	{
		errorPopupStageC.SetActive(true);
	}

	public void ExitPopupB()
	{
		errorPopupStageB.SetActive(false);
	}

	public void ExitPopupC()
	{
		errorPopupStageC.SetActive(false);
	}

    public void BtnPress()
    {
        SceneManager.LoadScene("Object Test");
    }

}
