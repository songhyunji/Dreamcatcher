using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class HomeManager : MonoBehaviour
{

	public void Scene1BtnPress()
	{
		SceneManager.LoadScene("Scene 1");
	}
	
	public void Scene2BtnPress()
	{
		SceneManager.LoadScene("Scene 2");
	}
	
	public void Scene3BtnPress()
	{
		SceneManager.LoadScene("Scene 3");
	}
	
	public void Scene4BtnPress()
	{
		SceneManager.LoadScene("Scene 4");
	}
}
