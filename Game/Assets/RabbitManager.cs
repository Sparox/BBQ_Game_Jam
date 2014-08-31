using UnityEngine;
using System.Collections;

public class RabbitManager : MonoBehaviour {

	public float rabbitLaunchedTime = 0f;
	public bool mustGenerate = false;
	public Transform RabbitPrefab;
	public Transform CatapultLineFront;
	public Transform CatapultLineBack;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if((rabbitLaunchedTime != 0f && Time.time - rabbitLaunchedTime > 1.5f) || mustGenerate)
		{
			Transform Rabbit = Instantiate(RabbitPrefab) as Transform;//, new Vector3(-0.6317098f, 0.9210251f, 0.1843131f), Quaternion.identity) as Transform; 
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).rayToMouse = new Ray (this.transform.position, Vector3.zero);
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).leftCatapultToProjectile = new Ray (CatapultLineFront.transform.position, Vector3.zero);
			Rabbit.parent = this.transform;
			Rabbit.localPosition = new Vector3(-0.6317098f, 0.9210251f, 0.1843131f);
			Rabbit.localScale = new Vector3(0.3f,0.3f,0.4483107f);
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapultLineFront = CatapultLineFront.GetComponent("LineRenderer") as LineRenderer;
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapultLineBack = CatapultLineBack.GetComponent("LineRenderer") as LineRenderer;
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).RabbitPrefab = RabbitPrefab;
			
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).spring = Rabbit.GetComponent <SpringJoint2D> ();
			(Rabbit.GetComponent("SpringJoint2D") as SpringJoint2D).connectedBody = this.rigidbody2D;
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapult = GameObject.Find("Catapult").transform;
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).LineRendererSetup ();
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).rayToMouse = new Ray ((Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapult.position, Vector3.zero);
			(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).leftCatapultToProjectile = new Ray (CatapultLineFront.transform.position, Vector3.zero);
			
			
			rabbitLaunchedTime = 0f;
			mustGenerate = false;
		}

	}
}
