using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
	private AudioSource _audioSource;
	public Player_subslope playerScript;

    void Start()
    {
        playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		_audioSource = GetComponent<AudioSource>();
    }


    public void OnPointerDown(PointerEventData ped)
	{
		if (!_audioSource.isPlaying)
		{
			_audioSource.Play();
		}
		playerScript.Jump();

	}
	
}
