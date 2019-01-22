using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	public Rune runeScript;
	public float speed = 0.01f;
	private void FixedUpdate()
	{
		if(runeScript.RuneSwitch==false)
		{
			if(transform.position.y<5.48)
			{
				transform.Translate(0, speed, 0);
			}

		}
	}
}
