using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple1 : MonoBehaviour {
	
	public GameObject player;
    public GameObject spawnBtn;
    public Player_subslope playerScript;

    private Rigidbody2D rb2D;
	private Transform pos;
    private Collider2D playerCollider;

	private bool inGround;

    public bool isHanging = true;
	public bool isTouch;
    public bool isAttatch;
    public bool isGround;
    public float boundX;

	public string saveName;

	private void Start()
	{
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		spawnBtn = GameObject.Find("SpawnBtn");
		playerCollider = player.GetComponent<Collider2D>();
        rb2D = GetComponent<Rigidbody2D>();
		pos = player.GetComponent<Transform>();
		rb2D.gravityScale = 0;

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
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

		if (inGround)
		{
			if (playerScript.isLeft)
			{
				pos.transform.Translate(Vector3.right * Time.deltaTime * 3);
			}
			else
			{
				pos.transform.Translate(Vector3.left * Time.deltaTime * 3);
			}

		}

	}

    private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
            isTouch = true;			
		}
		else if (other.collider.CompareTag("Ground"))
		{
			if (!isAttatch)
			{
				Debug.Log("save position");
				SaveData();
			}
		}
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("inTile"))
		{
			Debug.Log("땅에 닿음");
			inGround = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("inTile"))
		{
			inGround = false;
		}
	}

	public void SaveData()
	{
		var pos = this.transform.position;

		var posString = "";

		posString += pos.x + "," + pos.y;

		PlayerPrefs.SetString(saveName, posString);
	}

	public void LoadData()
	{
		var posData = PlayerPrefs.GetString(saveName).Split(',');

		var loadedPos = new Vector3(float.Parse(posData[0]), float.Parse(posData[1]), 0);

		this.transform.position = loadedPos;
	}

	public void PressInteractBtn()
    { 
		if (isTouch&&!isAttatch)
		{
            //jumpBtn = GameObject.Find("JumpBtn");
            //jumpBtn.GetComponent<JumpButton>().enabled = false;

			if (spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = false;
			}

			rb2D.gravityScale = 0;
            isAttatch = true;
            
        }
		else if(isAttatch)
		{
            //jumpBtn.GetComponent<JumpButton>().enabled = true;
			if (spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = true;
			}

            rb2D.gravityScale = 5;
			isAttatch = false;
		}
	}
}
