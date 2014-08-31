using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!this.renderer.isVisible && !this.rigidbody2D.isKinematic) {
			Destroy(this.gameObject);
			(GameObject.Find("CatapultSystem").GetComponent("RabbitManager") as RabbitManager).mustGenerate = true;
		}
	}
}
