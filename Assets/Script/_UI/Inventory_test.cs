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
	private int invenObject; // 0 == none, 1 == key, 2 == lily

	private void Start()
	{
		invenImg = GetComponent<Image>();
	}

	private void Update()
	{
		
	}

	public void Restart()
	{
		Debug.Log("Restart");
		invenImg.sprite = none;
	}

	public void GetKey()
	{
		Debug.Log("Get Key.");
		invenImg.sprite = key;
	}

	public void GetLily()
	{
		Debug.Log("Get Lily.");
		invenImg.sprite = lily;
	}

	public void UseKey()
	{
		Debug.Log("Use Key.");
		invenImg.sprite = none;
	}

	public void UseLily()
	{
		Debug.Log("Use Lily.");
		invenImg.sprite = none;
	}

}
