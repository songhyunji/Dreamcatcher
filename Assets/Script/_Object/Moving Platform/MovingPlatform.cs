using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

	public float maxY;
	public float minY;
	public float speed;
    public bool isWork = false;

	private Transform pos;
	private float posY;
	private bool goDown = false;
	
	private void Start()
	{
		pos = GetComponent<Transform>();
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(isWork)
        {
            Move();
        }
		

	}

    void Move()
    {
        posY = pos.position.y;

        if (goDown)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if (posY < minY)
            {
                goDown = false;
            }
        }
        else
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
            if (posY > maxY)
            {
                goDown = true;
            }
        }

    }
}
