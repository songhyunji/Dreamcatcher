using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnButton : MonoBehaviour, IPointerDownHandler
{
	private AudioSource _audioSource;

	public GameObject player;
	public GameObject wolf;
	public Player_subslope playerScript;

	//public HeavyApple heavyAppleScript;
	//public GameObject heavyApple;

	private Renderer player_renderer;
	[HideInInspector]
	public GameObject wolf_clone;
	public bool isSpawned = false;
	public float controlPosition;

	private void Start()
	{
        player = GameObject.Find("TestPlayer(Clone)");
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
        player_renderer = player.GetComponent<Renderer>();

		_audioSource = GetComponent<AudioSource>();
	}

	public void OnPointerDown(PointerEventData ped)
	{
		Debug.Log("spawn 버튼 눌렸음");
		if (playerScript.isGround||playerScript.onFoothold)
		{
			if (!isSpawned)
			{
				_audioSource.Play();

				wolf_clone = Instantiate(wolf, new Vector3(player_renderer.bounds.center.x, player_renderer.bounds.center.y - controlPosition), Quaternion.identity); // 스케일 player dir에 따라 조정
				wolf_clone.GetComponent<Transform>().localScale = new Vector3(-playerScript.dir, 1);
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
