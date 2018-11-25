using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyApple : MonoBehaviour {
	
	public GameObject player;
	private Rigidbody2D rb2D;
	private Transform pos;

	public bool isTouch;
	public bool isAttatch;
	public SpawnButton SpawnButtonscript;

	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (isTouch == false)
		{
			isAttatch = false;
		}
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = true;
			Debug.Log("is touch");
		}
		
	}
	
	private void OnCollisionExit2D(Collision2D other)
	{
		if (other.collider.CompareTag("Player"))
		{
			isTouch = false;
			Destroy(SpawnButtonscript.wolf_clone);
			SpawnButtonscript.isSpawned = false;
			rb2D.bodyType = RigidbodyType2D.Static;
		}
	}
	
	public void PressInteractBtn()
	{
		if (isTouch)
		{
			if (isAttatch == false)
			{
				Debug.Log("is attatch");
				isAttatch = true;
			}
			else
			{
				Debug.Log("is not attatch");
				isAttatch = false;
				rb2D.bodyType = RigidbodyType2D.Static;
				Destroy(SpawnButtonscript.wolf_clone);
				SpawnButtonscript.isSpawned = false;
			}
		}
	}
}
