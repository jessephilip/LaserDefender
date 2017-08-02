using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
	static MusicPlayer instance = null;

	// Use this for initialization
	void Start ()
	{
		if (instance != null && instance != this)
		{
			Destroy (gameObject);
			Debug.Log ("Duplicate music player self-destructing!");
		} else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
