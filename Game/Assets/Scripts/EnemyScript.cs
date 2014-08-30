using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		//If collide with Player
		if (other.tag == "Player") 
		{
			//Lvl up
			Destroy(this.gameObject);
		}
	}
}
