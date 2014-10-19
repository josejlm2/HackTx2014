using UnityEngine;
using System.Collections;
using Leap;

public class BlockScoreLogic : MonoBehaviour {

	public float speed; 

	bool m_hasBeenHit = false;
	bool goingForward = true; 
	public void ResetScore() {
		m_hasBeenHit = false;
	}
	public void setDirection( bool parameter){
		goingForward = parameter;

	}
	void OnCollisionEnter(Collision c) {
		if (m_hasBeenHit ) return;
		m_hasBeenHit = true;
		GameObject.Find("Score").GetComponent<ScoreDisplay>().m_score++;
	}

	void Start(){
				speed = 0.05f; 

		}


	
	//method used to move blocks towards screen 
	void moveAhead(){
		if (goingForward) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z - speed); 
		} else {
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (4 * speed)); 
		}
	}
	/*public void ChangeDirection(){
				//if (Input.GetButtonDown ("space")) {
						goingForward = false; 
				//}
		}*/

	void Update() {
		// clean up after ourselves...
		moveAhead(); 
		//ChangeDirection (); 
		if (transform.position.z < -20.0f) Destroy(gameObject);
	}
}
