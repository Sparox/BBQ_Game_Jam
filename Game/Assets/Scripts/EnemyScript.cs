using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public float enemyValue = 1f;
	HUDScript hud;

	public float enemyMove = 0.01f;

	void Update()
	{
		float x = transform.position.x;

		transform.position = new Vector3 (x-enemyMove, transform.position.y, transform.position.z);
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
		//If collide with Player
		/*if (other.tag == "Player") 
		{
		
			//On augmente le score en fonction de la valeur de l'enemy
			hud.IncreaseScore(enemyValue);
			
			//On kill l'enemy
			Destroy(this.gameObject);

		}*/
	
		if (other.tag == "Catapult") 
		{
			Destroy(this.gameObject);
			hud.DecreaseLife();
		}
	}
}
