﻿using UnityEngine;
using System.Collections;

public class LapinCollider : MonoBehaviour {
	private float elapse = 0f;
	private float frameRabbit = 0;
	private bool canFrame = false;

	HUDScript hud;
	public float enemyValue = 1f;
	public Collider2D enemyToDelete;

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
			elapse = Time.time;


			hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();
			hud.IncreaseScore(enemyValue);

			enemyToDelete = other;
			Animator enemyAnim = enemyToDelete.GetComponent("Animator") as Animator;
			enemyAnim.enabled = false;
			EnemyScript enemyScript = enemyToDelete.GetComponent("EnemyScript") as EnemyScript;
			enemyScript.enabled = false;
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