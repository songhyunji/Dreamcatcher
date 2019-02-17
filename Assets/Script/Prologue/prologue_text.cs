using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prologue_text : MonoBehaviour
{
	[TextArea]
	public string[] dialogues = new string[7];
	public float speed = 0.2f;
	public Text text;

	int i = 0;
	private bool isSaying = false;
	private bool isColor;

    void Start()
    {
		isSaying = true;
		StartCoroutine(Dialogue());
	}

	private void Update()
	{
		if(Input.touchCount > 0||Input.GetKeyDown(KeyCode.Space))
		{
			if(isSaying)
			{
				isSaying = false;
				StopAllCoroutines();
				if(i==3)
				{
					text.text = "어느날 숲으로 들어간 아버지가\n<color=red>사라져버리기</color> 전까진 말이죠.";
				}
				else if (i == 6)
				{
					text.text = "막연한 희망을 품고, 아이는 집을 나섭니다.\n어머니의 유품인 <color=red>붉은 로브</color>를 뒤집어쓰고…";
				}
				else
				{
					text.text = dialogues[i];
				}
			}
			else
			{
				if (i < dialogues.Length - 1)
				{
					text.text = "";
					i++;
					isSaying = true;
					StartCoroutine(Dialogue());
				}
				else
				{
					Debug.Log("end");
				}
			}
		}
	}

	IEnumerator Dialogue()
	{
		while(isSaying)
		{
			foreach (var dialogue in dialogues[i])
			{
				isSaying = true;
				if ((i == 3 && dialogue == '사') || (i == 6 && dialogue == '붉'))
				{
					isColor = true;
				}

				if ((i == 3 && dialogue == '전') || (i == 6 && dialogue == '를'))
				{
					isColor = false;
				}

				if(isColor)
				{
					text.text += "<color=red>" + dialogue + "</color>";
				}
				else
				{
					text.text += dialogue;
				}

				yield return new WaitForSeconds(speed);
			}
			isSaying = false;
		}

	}
}
