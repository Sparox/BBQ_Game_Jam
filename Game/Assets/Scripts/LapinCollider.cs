using UnityEngine;
using System.Collections;

public class LapinCollider : MonoBehaviour {
	private float elapse = 0f;

	void OnTriggerEnter2D(Collider2D other)
	{
		//Collisioin avec le chevalier
		if (other.tag == "Chevalier")
		{
			Animator anim = this.GetComponent("Animator") as Animator;
			anim.SetTrigger("Collision");
			this.rigidbody2D.isKinematic = true;
			elapse = Time.time;




		}
	}

	void Update(){
		if (Time.time -elapse>1) {
			Destroy(this.gameObject);
				}
	}
}