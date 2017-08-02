using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
	// values for the Draw Gizmo
	public float width = 3.0f;
	public float height = 1.0f;

	void OnTriggerEnter2D (Collider2D collider)
	{
		Destroy (collider.gameObject);
	}

	void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height, transform.position.z));
	}
}
