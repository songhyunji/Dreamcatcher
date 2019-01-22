using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_switch : MonoBehaviour
{

	public float maxY;
	public float minY;
	public float speed;
    public Button buttonScript;

	private Transform pos;
	private float posY;
	private bool goDown = false;
	
	private void Start()
	{
		pos = GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true)
        {
			MoveUp();
        }
		else
		{
			MoveDown();
		}

	}

    void MoveUp()
    {
        posY = pos.position.y;
		if (posY < maxY)
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
    }

	void MoveDown()
	{
		posY = pos.position.y;
		if (posY > minY)
		{
			transform.Translate(Vector3.down * speed * Time.deltaTime);
		}
	}
}
