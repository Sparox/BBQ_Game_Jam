using UnityEngine;
using System.Collections;

public class RabbitDragging : MonoBehaviour {

	public float maxStretch;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;

	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn = false;
	private Vector2 prevVelocity;

	void Awake () {
		spring = GetComponent <SpringJoint2D> ();
		catapult = spring.connectedBody.transform;
	}

	// Use this for initialization
	void Start () {
		LineRendererSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = collider2D as CircleCollider2D;
		circleRadius = circle.radius;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log(collider2D.bounds);
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
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
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
