using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	int score = 0;
	// Use this for initialization

	void Start () 
	{
		score = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI () {
		//GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "Game Over");

		GUI.Label (new Rect (Screen.width/2, 50, 1500, 1500), "<color=red><size=100>Score : " + score + "</size></color>");
		if (GUI.Button (new Rect (Screen.width / 2, Screen.height/2, 300, 100), "<color=red><size=20>Play again !</size></color>")) 
		{
			Application.LoadLevel (0);
		}
	}
}

