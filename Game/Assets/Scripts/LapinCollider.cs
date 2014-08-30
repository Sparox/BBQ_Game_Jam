using UnityEngine;
using System.Collections;

public class LapinCollider : MonoBehaviour {
	private float elapse = 0f;
	public float frameRabbit = 0;
	public bool canFrame = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		//Collisioin avec le chevalier
		if (other.tag == "Chevalier")
		{
			canFrame = true;
			Animator anim = this.GetComponent("Animator") as Animator;
			anim.SetTrigger("Collision");
			this.rigidbody2D.isKinematic = true;
			elapse = Time.time;




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
			}
		}
	}
}