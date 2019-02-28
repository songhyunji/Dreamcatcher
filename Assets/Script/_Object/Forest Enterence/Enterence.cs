using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enterence : MonoBehaviour
{
    public Sprite enterence_open;
    public Sprite enterence_close1;
    public Sprite enterence_close2;

    public Rune runeScript;

	public GameObject player;
	private Player_subslope playerScript;

	public float blinkSpeed;

    private bool playerin;
    private bool enterenceOpen = false;

    private SpriteRenderer enterenceSptireRenderer;
    private Animator animator;

	public Image img;

	public VcamDirectionInA1 VDA1;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("TestPlayer(Clone)");
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		enterenceSptireRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();


	}

    private void Update()
    {
        if(runeScript.RuneSwitch==false)
        {
            EnterenceOpen();
        }
    }

    public void EnterenceOpen()
    {
        Debug.Log("work");
        animator.SetBool("enterenceOpen", true);
        enterenceOpen = true;
    }

    public void PressInteractBtn()
    {
        if(playerin)
        {
            if(enterenceOpen)
            {
				img.gameObject.SetActive(true);
				playerScript.isSceneLoading = true;
				StartCoroutine(FadeImage(false));
			}
            else
            {
                StartCoroutine("Blink");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerin = true;

            VDA1.ColliderwithEntrance = true; // 문에 부딪힘 -> 연출 시작

            if(!enterenceOpen)
            {
                animator.SetBool("playerin", true);
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerin = false;

            if (!enterenceOpen)
            {
                animator.SetBool("playerin", false);
            }
        }

    }

    IEnumerator Blink()
    {
        animator.SetBool("playerInteract", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("playerInteract", false);
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
			playerScript.isSceneLoading = false;
			PlayerPrefs.SetFloat("posX", player.transform.position.x);
			PlayerPrefs.SetFloat("posY", player.transform.position.y);
			PlayerPrefs.SetString("SaveStage", "B1");

			SceneManager.LoadScene("B1");
		}
	}

}
