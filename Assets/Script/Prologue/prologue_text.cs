using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class prologue_text : MonoBehaviour
{
	[TextArea]
	public string[] dialogues = new string[7];
	public float speed = 0.2f;
	public Text text;
	public Image fade;
	public GameObject player;
	[HideInInspector]
	public GameObject player_object;

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
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Ended)
			{
				if (isSaying)
				{
					isSaying = false;
					StopAllCoroutines();
					if (i == 3)
					{
						text.text = "어느날 숲으로 들어간 아버지가\n\n<color=red>사라져버리기</color> 전까진 말이죠.";
					}
					else if (i == 6)
					{
						text.text = "막연한 희망을 품고, 아이는 집을 나섭니다.\n\n어머니의 유품인 <color=red>붉은 로브</color>를 뒤집어쓰고. . .";
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
						fade.gameObject.SetActive(true);
						StartCoroutine(FadeImage());
					}
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

				if ((i == 6 && dialogue == '어'))
				{
					speed = 0.1f; // 1번 0.1f 2번 0.2f
				}

				if (isColor)
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

	IEnumerator FadeImage()
	{
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				fade.color = new Color(0, 0, 0, i);
				yield return null;
			}

		CreatePlayer(new Vector3(-2.11f, -1.5f));

		PlayerPrefs.DeleteAll();

		PlayerPrefs.SetInt("wolf", 0); // 0 == false, 1 == true
		PlayerPrefs.SetFloat("posX", -2.11f);
		PlayerPrefs.SetFloat("posY", -1.5f);
		PlayerPrefs.SetString("SaveStage", "A0");
		Debug.Log("저장");

		Debug.Log("posX");
		Debug.Log(PlayerPrefs.GetFloat("posX"));
		Debug.Log("posY");
		Debug.Log(PlayerPrefs.GetFloat("posY"));
		Debug.Log("Scene Name");
		Debug.Log(PlayerPrefs.GetString("SaveStage"));

		SceneManager.LoadScene("A0");
	}

	public void CreatePlayer(Vector3 playerPosition)
	{
		player_object = Instantiate(player, playerPosition, Quaternion.identity);
	}
}
