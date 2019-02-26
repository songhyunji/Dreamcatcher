using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flytrap : MonoBehaviour
{
    public bool canEat = true;
    public GameObject player;
	public Player_subslope playerScript;

	private float playerposX;
	private float playerposY;
	private string loadSceneName = "";

	public Sprite flytrapOff;
	public Sprite flytrapOn;
	public Sprite flytrapEat;

	private AudioSource _audioSource;

	private void Start()
    {
        player = GameObject.Find("TestPlayer(Clone)");
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		_audioSource = GetComponent<AudioSource>();
	}

    private void FixedUpdate()
    {
        if(!canEat)
        {
			GetComponent<SpriteRenderer>().sprite = flytrapOn;
        }
        if(canEat)
        {
			GetComponent<SpriteRenderer>().sprite = flytrapOff;
        }
    }

    private void Eat()
    {
		_audioSource.Play();
		GetComponent<SpriteRenderer>().sprite = flytrapEat;
		playerScript.Die();
	}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && canEat)
        {
            Debug.Log("Eat");
            canEat = false;
            Eat();
        }
    }
    
}
