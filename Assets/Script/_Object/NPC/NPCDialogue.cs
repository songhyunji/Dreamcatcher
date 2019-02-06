using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
	private bool firstMeet = true;
	private bool isSpeaking;
	private bool playerIn;

	public string[] dialogues = new string[4];
	public Text _text;
	public GameObject img;
	public GameObject key;

	private void Start()
	{
		_text.text = "";
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			playerIn = true;
			if(firstMeet)
			{
				img.SetActive(true);
				StartCoroutine(npcDialogue());
			}
		}
	}

	IEnumerator npcDialogue()
	{
		firstMeet = false;
		foreach (string dialogue in dialogues)
		{
			_text.text = dialogue;
			yield return new WaitForSeconds(3);
		}
		_text.text = "";
		img.SetActive(false);
		isSpeaking = false;

		if(key!=null)
		{
			key.SetActive(true);
		}
	}
	
	public void PressInteractBtn()
	{
		if(!isSpeaking&&playerIn)
		{
			img.SetActive(true);
			isSpeaking = true;
			StartCoroutine(npcDialogue());
		}
	}

}
