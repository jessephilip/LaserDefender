using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public float speed = 2.0f;
	public float padding = 1.0f;

	// controls whether the ship moves left or right across the screen
	private bool moveLeft = true;

	private float confineShipLeft;
	private float confineShipRight;

	// Use this for initialization
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
	/// Enemy ships move automatically.
	/// </summary>
	void MoveShip ()
	{
		if (moveLeft) {
			// could have used transform.position += Vector3.left * speed * Time.deltaTime;
			transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
		} else {
			// could have used transform.position += Vector3.right * speed * Time.deltaTime;
			transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
		}
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (transform.position.x, confineShipLeft, confineShipRight);
		transform.position = temp;

		if (temp.x <= confineShipLeft)
		{
			moveLeft = false;
		} else if (temp.x >= confineShipRight)
		{
			moveLeft = true;
		}

		/* NOTES:
			Taken mostly from PlayerController with some auto movement

		*/
	}

	/// <summary>
	/// Confines the enemy ships' movements to the main camera.
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
