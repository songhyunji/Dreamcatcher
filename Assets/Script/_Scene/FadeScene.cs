using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour
{
    public GameObject player;
    public Image fade;
    public Image tutorial;

    public MapnameImage titleScript;

    private int dieRestart; // 0 == false, 1 == true
    public float fadeSpeed = 0.01f;

    private float playerposX;
    private float playerposY;
    private string loadSceneName = "";

    private void Awake()
    {
        dieRestart = PlayerPrefs.GetInt("dieRestart");
        if (dieRestart == 1)
        {
            fade.gameObject.SetActive(true);
            PlayerPrefs.SetInt("dieRestart", 0); //0 == false,1 == true
            StartCoroutine(DieFade());

            Debug.Log("DieFade");
        }
        else
        {
            StartCoroutine(FadeImage(fade, true, 0));
            Debug.Log("FadeImage case 0");
        }
    }

    private void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
    }

    public void HomeBtnPress()
    {
        Time.timeScale = 1;
        StartCoroutine(FadeImage(fade, false, 1));

    }

    public void RestartSceneFunc()
    {
        playerposX = PlayerPrefs.GetFloat("posX");
        playerposY = PlayerPrefs.GetFloat("posY");
        loadSceneName = PlayerPrefs.GetString("SaveStage");

        fade.gameObject.SetActive(true);
        StartCoroutine(FadeImage(fade, false, 2));
    }

    IEnumerator FadeImage(Image img, bool fadeAway, int num)
    {
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
            Debug.Log("End fade");

            switch (num)
            {
                case 0:
                    Time.timeScale = 1;
                    img.gameObject.SetActive(false);
                    if (SceneManager.GetActiveScene().name == "A0")
                    {
                        StartCoroutine(TutorialFade());
                    }
					else
					{
						titleScript.startFade = true;
						Debug.Log("startFade값 true로 변경");
					}
                    break;
                default:
                    break;
            }
        }
        else
        {
            img.gameObject.SetActive(true);
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }

            switch (num)
            {
                case 1:
                    Debug.Log("home btn");
                    Destroy(player);
                    SceneManager.LoadScene("Main");
                    break;
                case 2:
                    Debug.Log("restart btn");
                    player.transform.position = new Vector3(playerposX, playerposY);
                    SceneManager.LoadScene(loadSceneName);
                    break;
                default:
                    break;
            }

        }
    }

    IEnumerator DieFade()
    {
        for (float i = 1; i >= -1; i -= 0.1f)
        {
            fade.color = new Color(0.6509f, 0.0627f, 0.1176f, i);
            yield return null;
        }
        fade.gameObject.SetActive(false);
    }

    IEnumerator TutorialFade()
    {
        for (float i = 0; i <= 1; i += 0.015f)
        {
            tutorial.color = new Color(1, 1, 1, i);
            yield return null;
        }

        yield return new WaitForSeconds(2); // 2초 동안 tutorial img 띄워놓음

        for (float i = 1; i >= 0; i -= 0.015f)
        {
            tutorial.color = new Color(1, 1, 1, i);
            yield return null;
        }
        tutorial.gameObject.SetActive(false);
		titleScript.startFade = true;
		Debug.Log("startFade값 true로 변경");
	}

}