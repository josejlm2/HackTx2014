using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public GameObject explosion; // drag your explosion prefab here
	void OnCollisionEnter(){
		GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		//Destroy(gameObject); // destroy the grenade
		Destroy(expl, 3); // delete the explosion after 3 seconds
	}
}
