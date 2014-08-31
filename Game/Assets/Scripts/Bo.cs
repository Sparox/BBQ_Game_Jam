using UnityEngine;
using System.Collections;

public class Bo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		(GameObject.Find ("Bo")).audio.mute = false;
		(GameObject.Find ("Bo")).audio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
