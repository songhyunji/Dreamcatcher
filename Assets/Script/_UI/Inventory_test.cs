using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_test : MonoBehaviour
{
	public Sprite key;
	public Sprite lily;
	public Sprite none;
	private Image invenImg;
	private int invenNum; // 0 == none, 1 == key, 2 == lily

	private void Start()
	{
		invenImg = GetComponent<Image>();
		invenNum = PlayerPrefs.GetInt("inventoryNum");
		Debug.Log(invenNum);

		if (invenNum == 0)
		{
			invenImg.sprite = none;
		}
		else if (invenNum == 1)
		{
			invenImg.sprite = key;
		}
		else if (invenNum == 2)
		{
			invenImg.sprite = lily;
		}

	}

	public void Restart()
	{
		Debug.Log("Restart");
		PlayerPrefs.SetInt("inventoryNum", 0);
		invenImg.sprite = none;
	}

	public void GetKey()
	{
		Debug.Log("Get Key.");
		PlayerPrefs.SetInt("inventoryNum", 1);
		invenImg.sprite = key;
	}

	public void GetLily()
	{
		Debug.Log("Get Lily.");
		PlayerPrefs.SetInt("inventoryNum", 2);
		invenImg.sprite = lily;
	}

	public void UseKey()
	{
		Debug.Log("Use Key.");
		PlayerPrefs.SetInt("inventoryNum", 0);
		invenImg.sprite = none;
	}

	public void UseLily()
	{
		Debug.Log("Use Lily.");
		PlayerPrefs.SetInt("inventoryNum", 0);
		invenImg.sprite = none;
	}

}
