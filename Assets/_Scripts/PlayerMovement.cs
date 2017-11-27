﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5.0f;
	private Rigidbody rb;
	private Vector3 movement;
	private int groundMask;
	private float cameraRayLength = 100.0f;

	void Awake() 
	{
		rb = GetComponent<Rigidbody> ();
		groundMask = LayerMask.GetMask ("Ground");
	}

	void FixedUpdate() 
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");
		float vertical = Input.GetAxisRaw ("Vertical");

		Move (horizontal, vertical);

		Turning (horizontal, vertical);
	}

	private void Move(float horizontal, float vertical) 
	{
		movement.Set (horizontal, 0.0f, vertical);

		movement = movement.normalized * speed * Time.deltaTime;

		rb.MovePosition (transform.position + movement);
	}

	private void Turning(float horizontal, float vertical) 
	{
		int turnDirection = Mathf.RoundToInt((10 * horizontal) + (1 * vertical));
		// UP: 1, DOWN: -1, LEFT: -10, RIGHT: -10
		// UPPER LEFT: -10+1 = -9, UPPER RIGHT: 10+1 = 11
		// LOWER LEFT: -10-1: -11, LOWER RIGHT: 10-1 = 9

		switch (turnDirection) 
		{
			case 1:
				rb.rotation = Quaternion.Euler (0.0f, 0.0f, 0.0f);
				break;
			case 11:
				rb.rotation = Quaternion.Euler (0.0f, 45.0f, 0.0f);
				break;
			case 10:
				rb.rotation = Quaternion.Euler (0.0f, 90.0f, 0.0f);
				break;
			case 9:
				rb.rotation = Quaternion.Euler (0.0f, 125.0f, 0.0f);
				break;
			case -1:
				rb.rotation = Quaternion.Euler (0.0f, 180.0f, 0.0f);
				break;
			case -11:
				rb.rotation = Quaternion.Euler (0.0f, 225.0f, 0.0f);
				break;
			case -10:
				rb.rotation = Quaternion.Euler (0.0f, 270.0f, 0.0f);
				break;
			case -9:
				rb.rotation = Quaternion.Euler (0.0f, 315.0f, 0.0f);
				break;
		}
	}
}
