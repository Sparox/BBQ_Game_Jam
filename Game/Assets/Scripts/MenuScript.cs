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
		string scoreString = "<color=red><size=100>Score : " + score + "</size></color>";
		int scoreWidth = scoreString.Length * 10;

		string retryString = "<color=red><size=20>Play again !</size></color>";
		int retryWidth = retryString.Length * 10;
		//10 is a constant which will obviously vary as you change the font or its size,
		//so you'll need a little of pacience to get a good value there
		
		//GUI.Label(new Rect(Screen.width/2 - textWidth/2, Screen.height/2, textWidth, 20), myString);


		GUI.Label (new Rect (Screen.width / 2 - scoreWidth / 2, 50, scoreWidth+150, 150), scoreString);
		if (GUI.Button (new Rect (Screen.width / 2 - retryWidth / 2, Screen.height/2, retryWidth, 100), retryString)) 
		{
			Application.LoadLevel (1);
		}
	}
}

