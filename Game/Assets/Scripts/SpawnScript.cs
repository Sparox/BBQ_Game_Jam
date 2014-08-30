using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;

	public Transform EnemyGround;

	public float spawnTimeLaunch = 5f;
	public float spawnTimeRepeat = 5f;


	void Start () {
		InvokeRepeating("Respawn", spawnTimeLaunch, spawnTimeRepeat);
	}

	void Update(){

	}


	void Respawn () {
		Instantiate(EnemyGround, new Vector3(10 , this.transform.position.y , this.transform.position.z), new Quaternion(0, 180,0, 0));
	}
}
