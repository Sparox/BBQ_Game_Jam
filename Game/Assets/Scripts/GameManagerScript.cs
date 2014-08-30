using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {


	HUDScript hud;


	// Use this for initialization
	void Start () {
		hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
	}
	
	// Update is called once per frame
	void Update () {
		if (hud.GetLife () == 0) {
			//Load Menu(game over) scene
			Application.LoadLevel(1);
		}
	
	}
}
