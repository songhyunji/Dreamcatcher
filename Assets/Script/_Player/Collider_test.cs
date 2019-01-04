using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collider_test : MonoBehaviour
{
	public Player_subslope playerScript;
	public Animator animator;
    public GameObject InteractBtn;
	
	void Start() {
		
		animator = playerScript.GetComponent<Animator>();
    }
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			playerScript.isGround = true;
			//playerScript.onLadder = false;
			//Debug.Log("is Ground true");
		}
		
		if (other.CompareTag("Foothold")||other.CompareTag("HeavyFoothold"))
		{
			playerScript.isGround = true;
			playerScript.onFoothold = true;
			playerScript.isJumping = false;
			playerScript.animator.SetBool("isJumping",false);

            InteractBtn = GameObject.Find("InteractBtn");
            InteractBtn.GetComponent<Button>().enabled = false;
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
			playerScript.animator.SetBool("isJumping",true);
            //Debug.Log("공중에 떠있음");

            InteractBtn.GetComponent<Button>().enabled = true;
        }
		
		if (other.CompareTag("HeavyFoothold"))
		{
			playerScript.touchedHeavyFoolhold = false;
            InteractBtn.GetComponent<Button>().enabled = true;
        }
	}
}