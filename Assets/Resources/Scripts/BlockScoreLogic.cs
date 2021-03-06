﻿using UnityEngine;
using System.Collections;
using Leap;

public class BlockScoreLogic : MonoBehaviour {

	public float speed; 

	bool m_hasBeenHit = false;
	public void ResetScore() {
		m_hasBeenHit = false;
	}

	void OnCollisionEnter(Collision c) {
		if (m_hasBeenHit) return;
		m_hasBeenHit = true;
		GameObject.Find("Score").GetComponent<ScoreDisplay>().m_score++;
	}

	void Start(){
		speed = 0.05f; 
	}
	//method used to move blocks towards screen 
	void moveAhead(){
		transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed); 
	}

	void Update() {
		// clean up after ourselves...
		moveAhead(); 
		if (transform.position.z < -20.0f) {
			Destroy (gameObject);
		} else if (transform.position.y < -20.0f | transform.position.y > 20.0f) {
			Destroy (gameObject); 
		} else if (transform.position.x < -20.0f | transform.position.x > 20.0f) {
			Destroy (gameObject); 
		}

	}
}