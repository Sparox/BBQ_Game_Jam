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
		Spawn ();
	}
	
	// Update is called once per frame
	void Spawn () {
		Instantiate (obj [Random.Range (0, obj.GetLength (0))], transform.position, Quaternion.identity);
		Invoke("Spawn", spawn/*Random.Range(spawnMin, spawnMax)*/);
		
	}
}
