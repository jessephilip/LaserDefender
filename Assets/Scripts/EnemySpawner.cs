using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	// passed in GameObject to spawn
	public GameObject enemyPrefab;

	// Use this for initialization
	void Start ()
	{
		Spawn ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	/// <summary>
	/* -- NOTES --
	* Create an enemy that is passed in from editor
	* Instantiate creates an object, so, if assigning it to a variable, you have to create it as a GameObject
	* Instantiate takes a GameObject, Vector3 position, and Quaternion rotation
	* Vector3.zero is equivalent to Vector3(0,0,0);
	*/
	/// </summary>
	void Spawn ()
	{
		GameObject enemy = Instantiate (enemyPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		// to change the instantiated GameObject's parent (put the clone in the spawn folder)
		// (since this script is attached to a spawn point)
		enemy.transform.parent = transform;
	}
}
