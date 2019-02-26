using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{
	private bool firstMeet = true;
	private bool isSpeaking;
	private bool playerIn;
	private int inventoryIndex;

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
	private AudioSource _audioSource;

	public string saveName;

	private void Start()
	{
		_audioSource = GetComponent<AudioSource>();
		_text.text = "";
		inventoryIndex = PlayerPrefs.GetInt("inventoryNum"); // if player has lily, inventoryIndex == 2 -> line 109 won't work

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
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
		if(!isSpeaking)
		{
			isSpeaking = true;
			if (firstMeet)
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
					_audioSource.Play();
					key.SetActive(true);
				}
			}
			else
			{
				for (int i = 5; i <= 6; i++)
				{
					_text.text = dialogues[i];
					yield return new WaitForSeconds(3);
				}
				_text.text = "";
				img.SetActive(false);
				isSpeaking = false;
			}
		}
	}

	IEnumerator npcDialogue_after()
	{
		if(!isSpeaking)
		{
			isSpeaking = true;
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
			SaveData();
			Destroy(this.gameObject);
		}
	}

	public void PressInteractBtn()
	{
		wolf = PlayerPrefs.GetInt("wolf");
		if (!isSpeaking && playerIn && wolf == 0 && inventoryIndex != 2) // if player has lily(inventoryIndex == 2) -> it doesn't work
		{
			img.SetActive(true);
			StartCoroutine(npcDialogue());
		}
	}

	public void SaveData()
	{
		Destroy(this.gameObject);

		PlayerPrefs.SetString(saveName, "destroy");
	}

	public void LoadData()
	{
		var data = PlayerPrefs.GetString(saveName);

		if (data == "destroy")
		{
			Destroy(this.gameObject);
		}
	}

}
