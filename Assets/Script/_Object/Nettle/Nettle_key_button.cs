using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nettle_key_button : MonoBehaviour
{
    public Button buttonScript;

	private Rigidbody2D rb2D;
	
	private void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true)
        {
			rb2D.gravityScale = 5;
        }
	}
}
