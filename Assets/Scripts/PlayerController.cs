﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{	
	public float speed = 15.0f;

	// used to prevent the ship from going flush against the side of the screen
	public float padding = 1.0f;

	// used for clamping the player ship's movement
	private float confineShipLeft;
	private float confineShipRight;

	void Start ()
	{
		ConfineToCamera ();
	}

	// Update is called once per frame
	void Update ()
	{
		MoveShip ();
	}

	/// <summary>
	/// Moves the ship using the left or right arrow keys on the keyboard.
	/// </summary>
	void MoveShip ()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			// could have used transform.position += Vector3.left * speed * Time.deltaTime;
			transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
		} else if (Input.GetKey(KeyCode.RightArrow))
		{
			// could have used transform.position += Vector3.right * speed * Time.deltaTime;
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (transform.position.x, confineShipLeft, confineShipRight);
		transform.position = temp;

		/* NOTES:
			Could have used GetAxis("Horizontal") but couldn't figure out clamping the value
		*/
	}

	/// <summary>
	/// Confines the players movement to the main camera.
	/// </summary>
	void ConfineToCamera ()
	{
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		confineShipLeft = leftMost.x + padding;
		confineShipRight = rightMost.x - padding;
	}
}