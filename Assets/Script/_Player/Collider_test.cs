using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collider_test : MonoBehaviour
{
	public Player_subslope playerScript;
	public Animator animator;
	private Rigidbody2D rb2D;

	[SerializeField]
	private GameObject spawnBtn;
	
	void Start() {
		
		animator = playerScript.GetComponent<Animator>();
    }
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			playerScript.isGround = true;
			playerScript.onLadder = false;
			transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			//Debug.Log("is Ground true");
		}
		
		if (other.CompareTag("Foothold")||other.CompareTag("HeavyFoothold"))
		{
			playerScript.isGround = true;
			playerScript.onFoothold = true;
			playerScript.isJumping = false;
			if(spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = false;
			}

			//Debug.Log("발판 위에 착지");
		}
		
		if (other.CompareTag("HeavyFoothold"))
		{
			playerScript.touchedHeavyFoolhold = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			playerScript.isGround = false;
			//Debug.Log("is Ground false");
		}
		
		if (other.CompareTag("Foothold"))
		{
			playerScript.onFoothold = false;
			if (spawnBtn != null)
			{
				spawnBtn.GetComponent<SpawnButton>().enabled = true;
			}
			//Debug.Log("공중에 떠있음");
		}
		
		if (other.CompareTag("HeavyFoothold"))
		{
			playerScript.touchedHeavyFoolhold = false;
        }
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (spawnBtn == null)
		{
			spawnBtn = GameObject.FindWithTag("SpawnBtn");
		}
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}