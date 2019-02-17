using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prologue_fade : MonoBehaviour
{
	[TextArea]
	public string[] dialogues = new string[7];
	public Text text;

	int i = 0;

    void Start()
    {
		text.text = dialogues[i];
	}

	private void Update()
	{
		if(Input.touchCount > 0||Input.GetKeyDown(KeyCode.Space))
		{
			if (i < dialogues.Length - 1)
			{
				text.text = "";
				i++;
				text.text = dialogues[i];
			}
			else
			{
				Debug.Log("end");
			}
		}
	}
	
}
