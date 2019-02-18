using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
	private bool firstMeet = true;
	private bool isSpeaking;
	private bool playerIn;

	public string[] dialogues = new string[6];
	public Text _text;
	public GameObject img;
	public GameObject key;

	private int wolfEventEnd; // 1 == true, 0 == false;

	private void Start()
	{
		_text.text = "";
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			playerIn = true;
			wolfEventEnd = PlayerPrefs.GetInt("wolfEventEnd");
			if (firstMeet && wolfEventEnd == 0) // first meet && wolf event didn't end
			{
				img.SetActive(true);
				StartCoroutine(npcDialogue());
			}

			if(firstMeet && wolfEventEnd==1) // wolf event end -> wolf btn == true
			{
				Debug.Log("wolf");
				PlayerPrefs.SetInt("wolf", 1); // 1 == true, 0 == false;
			}

		}
	}

	IEnumerator npcDialogue()
	{
		if(firstMeet)
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

			if (key != null)
			{
				key.SetActive(true);
			}
		}
		else
		{
			for(int i=4;i<=5; i++)
			{
				_text.text = dialogues[i];
				yield return new WaitForSeconds(3);
			}
			_text.text = "";
			img.SetActive(false);
			isSpeaking = false;
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
