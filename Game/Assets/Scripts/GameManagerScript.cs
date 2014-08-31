using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {


	HUDScript hud;
	
	public GameObject[] obj;
	
	public Transform EnemyGround;
	public Transform EnemyMidGround;
	public Transform EnemySky;
	public float spawnTimeLaunch = 5f;
	public float spawnTimeRepeat = 0f;
	public float spawnStart = 20f;

	public Transform Heart;

	// Use this for initialization
	void Start () {

		hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();



		InvokeRepeating("Respawn", spawnTimeLaunch, spawnTimeRepeat);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hud.GetLife () == 0) 
		{
			//Load Menu(game over) scene
			Application.LoadLevel(2);
			Instantiate(Heart, new Vector3(-1.328481f, 4.818217f, 0), new Quaternion(0,0,0,0));

		}
	}


	void Respawn () {
		Instantiate(EnemyGround, new Vector3(spawnStart , -3.103981f , -10), new Quaternion(0, 0,0, 0));
		Instantiate (EnemyMidGround, new Vector3 (spawnStart, -2.064525f, -10), new Quaternion (0,0, 0, 0));
		Instantiate (EnemySky, new Vector3 (spawnStart, 2.57397f, -10), new Quaternion (0,0, 0, 0));
	}
}
