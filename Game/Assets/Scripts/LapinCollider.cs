using UnityEngine;
using System.Collections;

public class LapinCollider : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D other)
	{
		//Collisioin avec le chevalier
		if (other.tag == "Chevalier")
		{
			(this.GetComponent("Animator") as Animator).SetTrigger("Collision");
			this.rigidbody2D.isKinematic = true;
			bool mustDestroy= false;
			Debug.LogError((this.GetComponent("Animator") as Animator).GetCurrentAnimatorStateInfo(0).IsTag("LapinAction"));
			while (!mustDestroy  ) 
			{
				if ((this.GetComponent("Animator") as Animator).GetCurrentAnimatorStateInfo(0).loop != false) 
				{	
					mustDestroy=true;
					Destroy(this.gameObject);
				}

			}
			/*for (int i = 0; i < 20; i++) {
				Debug.LogError((this.GetComponent("Animator") as Animator).GetCurrentAnimatorStateInfo(0).IsTag("Collision"));
			}*/
		}
	}
}