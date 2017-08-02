using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	// passed in GameObject to spawn
	public GameObject enemyPrefab;

	// width and height for DrawGizmo
	public float width = 10.0f;
	public float height = 3.0f;

	// speed controls the movement of the spawner
	public float speed = 2.0f;

	// prevents the spawner from touching the sides
	public float padding = 4.0f;

	// controls whether the ship moves left or right across the screen
	private bool moveLeft = true;

	private float confineSpawnLeft;
	private float confineSpawnRight;

	// Use this for initialization
	void Start ()
	{
		ConfineToCamera ();

		// foreach child in the EnemySpawn location, spawn an enemy on that location
		foreach (Transform child in transform)
		{
			Spawn (child);
		}
	}

	// Update is called once per frame
	void Update () {

		MoveSpawner ();
	}

	/// <summary>
	/* -- NOTES --
	* Create an enemy that is passed in from editor
	* Instantiate creates an object, so, if assigning it to a variable, you have to create it as a GameObject
	* Instantiate takes a GameObject, Vector3 position, and Quaternion rotation
	* Vector3.zero is equivalent to Vector3(0,0,0);
	*/
	/// </summary>
	void Spawn (Transform child)
	{
		GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
		// to change the instantiated GameObject's parent (put the clone in the spawn folder)
		// (since this script is attached to a spawn point)
		enemy.transform.parent = child;
	}

	void MoveSpawner ()
	{
		if (moveLeft) {
			// could have used transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else {
			// could have used transform.position += new Vector 3 (speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		Vector3 temp = transform.position;
		temp.x = Mathf.Clamp (transform.position.x, confineSpawnLeft, confineSpawnRight);
		transform.position = temp;

		// simply toggling the moveLeft boolean can cause a loop where the spawner does not leave a side
		if (temp.x <= confineSpawnLeft)
		{
			moveLeft = false;
		} else if (temp.x >= confineSpawnRight)
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
		confineSpawnLeft = leftMost.x + padding;
		confineSpawnRight = rightMost.x - padding;
	}

	/// <summary>
	/// Draw wire cube around Enemy Spawn points
	/// </summary>
	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, transform.position.z));
	}
}
