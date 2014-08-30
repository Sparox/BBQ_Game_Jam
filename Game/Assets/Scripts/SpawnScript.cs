using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

	public GameObject[] obj;
	/*public float spawnMin = 1f;
	public float spawnMax = 2f;
*/
	public float spawn = 1f;

	// Use this for initialization
	void Start () {

	}

	void Update(){
		if (this.transform.position.x < 0) {
			Spawn ();
		}
	}
	
	// Update is called once per frame
	void Spawn () {
		Debug.Log ("Spawn");

		//Instantiate (this, new Vector3(this.transform.position.x + 10 , this.transform.position.y , this.transform.position.z), Quaternion.identity);
		//Invoke("Spawn", spawn/*Random.Range(spawnMin, spawnMax)*/);
		
	}
}
