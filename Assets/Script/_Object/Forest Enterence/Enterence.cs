using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enterence : MonoBehaviour
{
    public Sprite enterence_open;
    public Sprite enterence_close1;
    public Sprite enterence_close2;

    public Rune runeScript;

    public float blinkSpeed;

    private bool playerin;
    private bool enterenceOpen = false;

    private SpriteRenderer enterenceSptireRenderer;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
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
                Debug.Log("다음 스테이지로 이동");
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

}
