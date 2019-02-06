using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_switch_horizontal : MonoBehaviour
{

	public float maxX;
	public float minX;
	public float speed;
	public bool rightleft;
	public bool leftright;
    public Button buttonScript;

	[SerializeField]
	private Transform pos;
	[SerializeField]
	private float posX;
	private bool goDown = false;
	
	private void Start()
	{
		pos = GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(buttonScript.isOn == true)
        {
			if(rightleft)
			{
				MoveRight();
			}
			else if(leftright)
			{
				MoveLeft();
			}
			
        }
		else
		{
			if (rightleft)
			{
				MoveLeft();
			}
			else if (leftright)
			{
				MoveRight();
			}
		}

	}

    void MoveRight()
    {
        posX = pos.position.x;
		if (posX < maxX)
		{
			transform.Translate(Vector3.right * speed * Time.deltaTime);
		}
    }

	void MoveLeft()
	{
		posX = pos.position.x;
		if (posX > minX)
		{
			transform.Translate(Vector3.left * speed * Time.deltaTime);
		}
	}
}
