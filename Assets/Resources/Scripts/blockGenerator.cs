using UnityEngine;
using System.Collections;

public class blockGenerator : MonoBehaviour {
	
	public int spawnRate = 1;
	private float timeSinceLastSpawn = 0;
	
	public GameObject oneCube;

	public int count; 
	// Use this for initialization
	void Start () {
		//Debug.Log("ran cube creator");
		count = 0; 
	}
	
	// Update is called once per frame
	void Update () {
		
		//timeSinceLastSpawn += Time.realtimeSinceStartup;
		//Debug.Log("running cube creator" + timeSinceLastSpawn );
		// if ( timeSinceLastSpawn > spawnRate )
		//  {
		//Clone the cubes and randomly place them
		count = count + 1; 
		if (count.Equals(50)) {
			GameObject newCube = (GameObject)GameObject.Instantiate (oneCube);
		
			newCube.transform.position = new Vector3 (0, 0, 20.0f);
		
			newCube.transform.Translate (Random.Range (-8, 8), Random.Range (0, 8), 1.0f);
			timeSinceLastSpawn = 0;
			//Debug.Log("cube created");
			// }
			count = 0; 
		}
	}
}