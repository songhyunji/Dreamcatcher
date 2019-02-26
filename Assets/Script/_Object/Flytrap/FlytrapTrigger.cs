using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlytrapTrigger : MonoBehaviour
{
    public Flytrap flytrapScript;
    private List<Collider2D> objectList = new List<Collider2D>();

	private SpriteRenderer _spriteRenderer;
	public Sprite flytrapTriggerOn;
	public Sprite flytrapTriggerOff;

	private AudioSource _audioSource;

	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_audioSource = GetComponent<AudioSource>();
	}

	private void Update()
    {
        if (objectList.Count > 0)
        {
            flytrapScript.canEat = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
		if(!_audioSource.isPlaying)
		{
			_audioSource.Play();
		}
		_spriteRenderer.sprite = flytrapTriggerOn;
        objectList.Add(collision);
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
		objectList.Remove(collision);
        StartCoroutine("CannotEat");
    }

    IEnumerator CannotEat()
    {
        if(objectList.Count==0)
        {
			_spriteRenderer.sprite = flytrapTriggerOff;
			yield return new WaitForSeconds(0.5f);
            flytrapScript.canEat = true;
        }
    }
}
