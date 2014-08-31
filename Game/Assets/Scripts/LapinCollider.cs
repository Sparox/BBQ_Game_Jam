using UnityEngine;
using System.Collections;

public class LapinCollider : MonoBehaviour {
	private float frameRabbit = 0;
	private bool canFrame = false;
	private bool redimOk = false;
	HUDScript hud;
	public float enemyValue = 1f;
	public Collider2D enemyToDelete = new Collider2D();


	void OnTriggerEnter2D(Collider2D other)
	{
		//Collisioin avec le chevalier
		if (other.tag == "Chevalier")
		{

			canFrame = true;
			Animator anim = this.GetComponent("Animator") as Animator;
			anim.SetTrigger("Collision");
			this.rigidbody2D.isKinematic = true;
			this.collider2D.enabled = false;
			this.audio.mute = false;
			this.audio.Play();


			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(enemyValue);

			enemyToDelete = other;
			Animator enemyAnim = enemyToDelete.GetComponent("Animator") as Animator;
			enemyAnim.enabled = false;
			EnemyScript enemyScript = enemyToDelete.GetComponent("EnemyScript") as EnemyScript;
			enemyScript.enabled = false;
		}

		if (other.tag == "Ground" && !this.rigidbody2D.isKinematic) 
		{
			canFrame = true;
			Animator anim = this.GetComponent("Animator") as Animator;
			anim.SetTrigger("CollisionSol");
			this.rigidbody2D.isKinematic = true;
			this.collider2D.enabled = false;

		}
	}

	void Update(){
		if(canFrame)
		{
			frameRabbit ++;
			if (frameRabbit == 60 ) 
			{
				frameRabbit = 0;
				Destroy(this.gameObject);
				Destroy(enemyToDelete.gameObject);

			}
		}
	}
}