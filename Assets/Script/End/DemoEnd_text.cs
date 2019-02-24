using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DemoEnd_text : MonoBehaviour
{
	public Image img;

	private bool isFirst;
	private bool isSecond;

	public GameObject firstText;
	public GameObject secondText;

    void Start()
    {
		StartCoroutine(FadeImage(true));
	}

	private void Update()
	{
		if(Input.touchCount > 0||Input.GetKeyDown(KeyCode.Space))
		{
			if(!isFirst && !isSecond)
			{
				StopAllCoroutines();
				StartCoroutine(FadeImage(false));
			}
			else if(isFirst && !isSecond)
			{
				StopAllCoroutines();
				StartCoroutine(FadeImage(false));
			}

		}
	}

	IEnumerator FadeImage(bool fadeAway)
	{
		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}


		}
		else
		{
			for (float i = 0; i <= 1; i += Time.deltaTime)
			{
				img.color = new Color(0, 0, 0, i);
				yield return null;
			}

			if (!isFirst && !isSecond)
			{
				isFirst = true;
				firstText.SetActive(false);
				secondText.SetActive(true);
				StartCoroutine(FadeImage(true));
			}
			else if (isFirst && !isSecond)
			{
				isSecond = true;
				SceneManager.LoadScene("Main");
			}

		}
	}
}
