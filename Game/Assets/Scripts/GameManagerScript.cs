using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {


	HUDScript hud;
	
	public GameObject[] obj;
	
	public Transform EnemyGround;
	public Transform EnemyMidGround;
	public float spawnTimeLaunch = 5f;
	public float spawnTimeRepeat = 0f;
	public float spawnStart = 20f;



	// Use this for initialization
	void Start () {
		hud = GameObject.Find("Main Camera").GetComponent<HUDScript>();



		InvokeRepeating("Respawn", spawnTimeLaunch, spawnTimeRepeat);
	}
	
	// Update is called once per frame
	void Update () {
		if (hud.GetLife () == 0) {
			//Load Menu(game over) scene
			Application.LoadLevel(1);
		}
	}

	void Respawn () {
		Instantiate(EnemyGround, new Vector3(spawnStart , -2.717418f , -10), new Quaternion(0, 0,0, 0));
		Instantiate (EnemyMidGround, new Vector3 (spawnStart, -2.064525f, -10), new Quaternion (0,0, 0, 0));
	}
}
