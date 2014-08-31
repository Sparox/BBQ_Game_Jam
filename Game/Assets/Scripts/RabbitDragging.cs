using UnityEngine;
using System.Collections;

public class RabbitDragging : MonoBehaviour {

	public float maxStretch;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;

	public SpringJoint2D spring;
	public Transform catapult;
	public Ray rayToMouse;
	public Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn = false;
	private Vector2 prevVelocity;

	public Transform RabbitPrefab;


	private float rabbitLaunchedTime = 0f;

	

	// Use this for initialization
	void Start () {
		spring = GetComponent <SpringJoint2D> ();
		catapult = spring.connectedBody.transform;
		LineRendererSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		circleRadius = 0f;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if(collider2D.bounds.Contains(Input.mousePosition)){
				spring.enabled = false;
				clickedOn = true;
			}
		}
		if (clickedOn)
			Dragging ();

		if (spring != null) {
			if(!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude) {
				Destroy(spring);
				rigidbody2D.velocity = prevVelocity;
			}

			if(!clickedOn)
				prevVelocity = rigidbody2D.velocity;

			LineRendererUpdate ();
		} else {
			//catapultLineFront.enabled = false;
			//catapultLineBack.enabled = false;
		}

		if(rabbitLaunchedTime != 0f)
		{
			if(Time.time - rabbitLaunchedTime > 3f)
			{
				LineRendererSetup();
				rayToMouse = new Ray (catapult.position, Vector3.zero);
				leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);

				Transform Rabbit = Instantiate(RabbitPrefab) as Transform;//, new Vector3(-0.6317098f, 0.9210251f, 0.1843131f), Quaternion.identity) as Transform; 
				
				Rabbit.parent = GameObject.Find("CatapultSystem").transform;
				Rabbit.localPosition = new Vector3(-0.6317098f, 0.9210251f, 0.1843131f);
				Rabbit.localScale = new Vector3(0.1569086f,0.1569088f,0.4483107f);
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapultLineFront = catapultLineFront;
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapultLineBack = catapultLineBack;
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).RabbitPrefab = RabbitPrefab;

				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).spring = Rabbit.GetComponent <SpringJoint2D> ();
				(Rabbit.GetComponent("SpringJoint2D") as SpringJoint2D).connectedBody = GameObject.Find("Catapult").rigidbody2D;
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapult = (Rabbit.GetComponent("RabbitDragging") as RabbitDragging).spring.connectedBody.transform;
				LineRendererSetup ();
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).rayToMouse = new Ray ((Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapult.position, Vector3.zero);
				(Rabbit.GetComponent("RabbitDragging") as RabbitDragging).leftCatapultToProjectile = new Ray ((Rabbit.GetComponent("RabbitDragging") as RabbitDragging).catapultLineFront.transform.position, Vector3.zero);


				rabbitLaunchedTime = 0f;
			}
		}

	}

	void LineRendererSetup()
	{
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position -new Vector3(0,-3,0));
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position - new Vector3(0,-3,0));

		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";

		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}

	void OnMouseDown() {
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp() {
		spring.enabled = true;
		rigidbody2D.isKinematic = false;
		clickedOn = false;
		rabbitLaunchedTime = Time.time;

	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		if(catapultToMouse.sqrMagnitude > maxStretchSqr) 
		{
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}

		mouseWorldPoint.z = transform.position.z;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint (catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
	}
}
