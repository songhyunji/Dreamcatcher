using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{

	public GameObject player;
	public GameObject wolf;
	public Player_subslope playerScript;

	private Renderer player_renderer;
	private GameObject wolf_clone;
	private bool isSpawned = false;

	private void Start()
	{
		player_renderer = player.GetComponent<Renderer>();
	}

	public void OnPointerDown(PointerEventData ped)
	{
		Debug.Log("spawn 버튼 눌렸음여");
		if (playerScript.isGround||playerScript.isTouching)
		{
			if (!isSpawned)
			{
				wolf_clone = Instantiate(wolf, player_renderer.bounds.center, Quaternion.identity);
				isSpawned = true;
			
			}
			else
			{
				Destroy(wolf_clone);
				isSpawned = false;
			}
		}


	}
	
	
}
