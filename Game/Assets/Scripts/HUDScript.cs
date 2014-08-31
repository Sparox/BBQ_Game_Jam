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

		if (life == 0) 
		{
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
		GUI.Label(new Rect(10,10,100,30), "Score : " + (int)playerScore);

		GUI.Label (new Rect (100, 10, 100, 30), "Life : " + life);

	}
}
