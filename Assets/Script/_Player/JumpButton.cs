using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{

	public Player_subslope playerScript;


	public void OnPointerDown(PointerEventData ped)
	{
		playerScript.Jump();

		//if (playerScript.isTouching)
		//{
		//	playerScript.exitLadder = true;
		//}
	}
	
}
