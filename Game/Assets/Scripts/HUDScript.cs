using UnityEngine;
using System.Collections;

public class HUDScript : MonoBehaviour {

	float playerScore = 0;
	int life = 3;

	void Update() 
	{
		//playerScore += Time.deltaTime;

	
	}
	
	public void IncreaseScore(float amount)
	{
		playerScore += amount;
	}
	
	public void DecreaseScore(float amount)
	{
		playerScore -= amount;
	}

	public int GetLife()
	{
		return life;
	}
	public void IncreaseLife()
	{
		life++;
	}

	public void DecreaseLife()
	{
		life--;

		if (life == 2) 
		{
			Destroy(GameObject.Find ("life3"));

		} else if (life == 1) 
		{
			Destroy(GameObject.Find ("life2"));
		//	GameObject.Find ("life2").renderer.enabled = false;
		}


		else if (life == 0) 
		{
			Destroy(GameObject.Find ("Hearts"));
			//GameObject.Find ("life1").renderer.enabled = false;
			Application.LoadLevel (1);
			PlayerPrefs.SetInt("Score", (int)playerScore);
		}
	}
	                                  
	void OnDisable()
	{
		PlayerPrefs.SetInt("Score", (int)playerScore * 100);
	}
	void OnGUI()
	{
		GUI.Label(new Rect(70,120,100,30), "Score : " + (int)playerScore);

		//GUI.Label (new Rect (850, 10, 100, 30), "Life : " + life);

	}
}
