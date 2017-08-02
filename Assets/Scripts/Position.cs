using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
	/// <summary>
	/// Draws a wire frame circle surrounding the object this script is attached to.
	/// Do not call OnDrawGizmos because it is called by the Unity Editor.
	/// </summary>
	void OnDrawGizmos ()
	{
		Gizmos.DrawWireSphere (transform.position, 1);
	}
}
