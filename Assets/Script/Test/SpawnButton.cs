using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{

	public GameObject player;
	public GameObject wolf;

	private Renderer player_renderer;
	private GameObject wolf_clone;
	private bool isSpawned = false;

	private void Start()
	{
		player_renderer = player.GetComponent<Renderer>();
	}

	public void OnPointerDown(PointerEventData ped)
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
