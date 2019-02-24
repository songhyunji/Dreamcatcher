using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using UnityEngine.UI;

public class DemoEnd : MonoBehaviour {
	
    public GameObject player;

	public Image img;

    void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
		{
			Destroy(player);
			img.gameObject.SetActive(true);
			StartCoroutine(FadeImage(false));
        }
    }

	IEnumerator FadeImage(bool fadeAway)
	{
		if (fadeAway)
		{
			for (float i = 1; i >= 0; i -= Time.deltaTime)
			{
				img.color = new Color(1, 1, 1, i);
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
			PlayerPrefs.DeleteAll();
			SceneManager.LoadScene("Demo End");
		}
	}
}
