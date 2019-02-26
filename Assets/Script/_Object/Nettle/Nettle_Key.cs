using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_Key : MonoBehaviour
{
	public Player_subslope playerScript;
	public Inventory_test invenScript;

	private AudioSource _audioSource;
	public AudioClip getItemSound;

	public string saveName;

	private void Start()
	{
		playerScript = GameObject.Find("TestPlayer(Clone)").GetComponent<Player_subslope>();
		_audioSource = GetComponent<AudioSource>();

		if (PlayerPrefs.HasKey(saveName))
		{
			LoadData();
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			_audioSource.clip = getItemSound;
			_audioSource.Play();
			Invoke("DestroyItem", _audioSource.clip.length);
		}
	}

	private void DestroyItem()
	{
		invenScript.GetKey();
		SaveData();
	}

	public void SaveData()
	{
		Destroy(this.gameObject);

		PlayerPrefs.SetString(saveName, "destroy");
	}

	public void LoadData()
	{
		var data = PlayerPrefs.GetString(saveName);

		if (data == "destroy")
		{
			Destroy(this.gameObject);
		}
	}

}
