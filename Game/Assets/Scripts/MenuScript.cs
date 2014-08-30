using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	int score = 0;
	// Use this for initialization
	void Start () {
		score = PlayerPrefs.GetInt ("Score");
	}

	void OnGUI () {
		GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "Game Over");
		GUI.Label (new Rect (Screen.width / 2 - 40, 100, 100, 30), "Score : " + score);
		if (GUI.Button (new Rect (Screen.width / 2 - 30, 300, 100, 30), "Retry?")) {
			Application.LoadLevel (0);
		}
	}
}

