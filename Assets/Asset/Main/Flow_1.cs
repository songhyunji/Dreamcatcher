using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flow_1 : MonoBehaviour
{
	public float scrollSpeed;
	Canvas canvas;
	float w;

	private Vector3 startPosition;

	private void Start()
	{
		startPosition = GetComponent<RectTransform>().anchoredPosition;
		canvas = FindObjectOfType<Canvas>();
		w = GetComponent<RectTransform>().rect.width;
	}

	private void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, w);
		GetComponent<RectTransform>().anchoredPosition = startPosition + Vector3.left * newPosition;
	}
}
