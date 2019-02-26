using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractBtnSound : MonoBehaviour
{
	private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
		_audioSource = GetComponent<AudioSource>();
    }

	public void PressInteractBtn()
	{
		Debug.Log("interact 버튼 눌렸음");
		_audioSource.Play();
	}
}
