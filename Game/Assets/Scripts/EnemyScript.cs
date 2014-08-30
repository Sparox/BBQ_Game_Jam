using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float enemyValue = 1f;
	HUDScript hud;

	void OnTriggerEnter2D(Collider2D other)
	{
		//If collide with Player
		if (other.tag == "Player") 
		{
			//On augmente le score en fonction de la valeur de l'enemy
			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(enemyValue);

			//On kill l'enemy
			Destroy(this.gameObject);
		}
	}
}
