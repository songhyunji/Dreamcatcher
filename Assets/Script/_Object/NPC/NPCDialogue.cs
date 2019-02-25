using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
	private bool firstMeet = true;
	private bool isSpeaking;
	private bool playerIn;

	[TextArea]
	public string[] dialogues = new string[7];
	[TextArea]
	public string[] dialogues_after = new string[5];
	public Text _text;
	public GameObject img;
	public GameObject key;

	public Inventory_test invenScript;

	private int wolfEventEnd; // 1 == true, 0 == false;
	private int wolf; // 1 == true, 0 == false

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
			wolf = PlayerPrefs.GetInt("wolf");
			if (firstMeet && wolfEventEnd == 0) // first meet && wolf event didn't end
			{
				img.SetActive(true);
				StartCoroutine(npcDialogue());
			}

			if(firstMeet && wolfEventEnd == 1 && wolf == 0) // wolf event end -> wolf btn == true
			{
				img.SetActive(true);
				StartCoroutine(npcDialogue_after());
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
			for(int i=5;i<=6; i++)
			{
				_text.text = dialogues[i];
				yield return new WaitForSeconds(3);
			}
			_text.text = "";
			img.SetActive(false);
			isSpeaking = false;
		}

	}

	IEnumerator npcDialogue_after()
	{
		invenScript.UseLily();
		foreach (string dialogue in dialogues_after)
		{
			_text.text = dialogue;
			yield return new WaitForSeconds(3);
		}
		_text.text = "";
		img.SetActive(false);
		isSpeaking = false;
		PlayerPrefs.SetInt("wolf", 1); // 1 == true, 0 == false;
	}

	public void PressInteractBtn()
	{
		wolf = PlayerPrefs.GetInt("wolf");

		if (!isSpeaking && playerIn && wolf == 0)
		{
			img.SetActive(true);
			isSpeaking = true;
			StartCoroutine(npcDialogue());
		}
	}

}
