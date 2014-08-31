using UnityEngine;
using System.Collections;

public class StartMenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI () {
		//GUI.Label (new Rect (Screen.width / 2 - 40, 50, 80, 30), "Game Over");

		
		/*string retryString = "<color=red><size=20>Play  !</size></color>";
		int retryWidth = retryString.Length * 10;
	

		if (GUI.Button (new Rect (Screen.width / 2 - retryWidth / 2, Screen.height/2, retryWidth, 100), retryString)) 
		{

		}*/
	}
	void OnMouseDown()
	{
		Debug.Log ("test");
		Application.LoadLevel (1);
	}
}
