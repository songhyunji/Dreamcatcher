using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
	private bool isSpeaking;
	private bool playerIn;

	public string[] dialogues = new string[4];
	public Text _text;

	private void Start()
	{
		_text.text = "";
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			playerIn = true;
		}
	}

	IEnumerator npcDialogue()
	{
		foreach (string dialogue in dialogues)
		{
			_text.text = dialogue;
			yield return new WaitForSeconds(3);
		}
		_text.text = "";
		isSpeaking = false;
	}
	
	public void PressInteractBtn()
	{
		if(!isSpeaking&&playerIn)
		{
			isSpeaking = true;
			StartCoroutine(npcDialogue());
		}
	}

}
