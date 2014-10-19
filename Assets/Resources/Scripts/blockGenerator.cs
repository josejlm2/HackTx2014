using UnityEngine;
using System.Collections;

public class blockGenerator : MonoBehaviour {
	
	public int spawnRate = 1;
	private float timeSinceLastSpawn = 0;
	
	public GameObject oneCube;
	
	// Use this for initialization
	void Start () {
		//Debug.Log("ran cube creator");
	}
	
	// Update is called once per frame
	void Update () {
		
		//timeSinceLastSpawn += Time.realtimeSinceStartup;
		//Debug.Log("running cube creator" + timeSinceLastSpawn );
		// if ( timeSinceLastSpawn > spawnRate )
		//  {
		//Clone the cubes and randomly place them
		GameObject newCube = (GameObject)GameObject.Instantiate(oneCube);
		
		newCube.transform.position = new Vector3(0, 0, 20.0f);
		
		newCube.transform.Translate(Random.Range(-100, 100), Random.Range(0,100), 1.0f);
		
		timeSinceLastSpawn = 0;
		//Debug.Log("cube created");
		// }
	}
}