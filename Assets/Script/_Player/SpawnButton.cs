using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{

	public GameObject player;
	public GameObject wolf;
	public Player_subslope playerScript;

	//public HeavyApple heavyAppleScript;
	//public GameObject heavyApple;

	private Renderer player_renderer;
	[HideInInspector]
	public GameObject wolf_clone;
	public bool isSpawned = false;

	private void Start()
	{

        player = GameObject.Find("TestPlayer");
        playerScript = GameObject.Find("TestPlayer").GetComponent<Player_subslope>();
        player_renderer = player.GetComponent<Renderer>();
	}

	public void OnPointerDown(PointerEventData ped)
	{
		Debug.Log("spawn 버튼 눌렸음");
		if (playerScript.isGround||playerScript.onFoothold)
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

			/*if (heavyAppleScript.isTouch && heavyAppleScript.isAttatch)
			{
				heavyApple.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
			}*/
		}

	}
	
	
}
