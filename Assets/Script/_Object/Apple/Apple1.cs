using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple1 : MonoBehaviour {
	
	public GameObject player;
    public GameObject jumpBtn;
    public GameObject spawnBtn;
    public Player_subslope playerScript;

    private Rigidbody2D rb2D;
	private Transform pos;
    private Collider2D playerCollider;

    public bool isHanging = true;
	public bool isTouch;
    public bool isAttatch;
    public bool isGround;
    public float boundX;

    private void Start()
	{
        player = GameObject.Find("TestPlayer");
        playerScript = GameObject.Find("TestPlayer").GetComponent<Player_subslope>();
        playerCollider = player.GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
		pos = player.GetComponent<Transform>();
		rb2D.gravityScale = 0;
	}

    private void FixedUpdate()
    {
        if (isAttatch)
        {
            if (playerScript.isLeft)
            {
                transform.position = new Vector2(playerCollider.bounds.center.x - boundX, playerCollider.bounds.center.y + 0.3f);
            }
            else
            {
                transform.position = new Vector2(playerCollider.bounds.center.x + boundX, playerCollider.bounds.center.y + 0.3f);
            }

        }

    }

    private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
            isTouch = true;			
		}
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = false;
		}
	}
	
	public void PressInteractBtn()
    { 
		if (isTouch&&!isAttatch)
		{
            jumpBtn = GameObject.Find("JumpBtn");
            jumpBtn.GetComponent<JumpButton>().enabled = false;

            spawnBtn = GameObject.Find("SpawnBtn");
            spawnBtn.GetComponent<SpawnButton>().enabled = false;

            rb2D.gravityScale = 0;
            isAttatch = true;
            
        }
		else if(isAttatch)
		{
            jumpBtn.GetComponent<JumpButton>().enabled = true;
            spawnBtn.GetComponent<SpawnButton>().enabled = true;

            rb2D.gravityScale = 1;
			isAttatch = false;
		}
	}
}
