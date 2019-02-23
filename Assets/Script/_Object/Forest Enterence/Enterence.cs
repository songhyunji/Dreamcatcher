using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enterence : MonoBehaviour
{
    public Sprite enterence_open;
    public Sprite enterence_close1;
    public Sprite enterence_close2;

    public Rune runeScript;

	public GameObject player;

	public float blinkSpeed;

    private bool playerin;
    private bool enterenceOpen = false;

    private SpriteRenderer enterenceSptireRenderer;
    private Animator animator;

    public VcamDirectionInA1 VDA1;

	// Start is called before the first frame update
	void Start()
    {
		player = GameObject.Find("TestPlayer(Clone)");
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
				LoadScene();
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

	private void LoadScene()
	{
		PlayerPrefs.SetFloat("posX", player.transform.position.x);
		PlayerPrefs.SetFloat("posY", player.transform.position.y);
		PlayerPrefs.SetString("SaveStage", "B1");

		SceneManager.LoadScene("B1");
	}

}
