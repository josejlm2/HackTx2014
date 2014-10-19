using UnityEngine;
using System.Collections;

public class AudioAnalyzer: MonoBehaviour {
	public AudioSource song;
	public GameObject cube;
	public Material red;
	public Material blue;
	public Material green;
	public int spawnRate = 1;
	private float timeSinceLastSpawn = 0;
	
	public GameObject oneCube;
	public GameObject blueCube;
	public GameObject redCube;
	public GameObject greenCube;
	public bool blueCheck = true;
	public bool redCheck = true;

	float[] historyBuffer = new float[43];
	float time = 0;
	// Use this for initialization
	void Start () {
		//print(Time.realtimeSinceStartup);
		float time = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		print(Time.realtimeSinceStartup);
		//compute instant sound energy
		float[] channelRight = song.audio.GetSpectrumData (1024, 1, FFTWindow.Hamming);
		float[] channelLeft = song.audio.GetSpectrumData (1024, 2, FFTWindow.Hamming);
		
		float e = sumStereo (channelLeft, channelRight);
		
		//compute local average sound evergy
		float E = sumLocalEnergy ()/historyBuffer.Length; // E being the average local sound energy
		
		//calculate variance
		float sumV = 0;
		for (int i = 0; i< 43; i++)
			sumV += (historyBuffer[i]-E)*(historyBuffer[i]-E);
		
		float V = sumV/historyBuffer.Length;
		float constant = (float)((-0.0025714 * V) + 1.5142857);
		
		float[] shiftingHistoryBuffer = new float[historyBuffer.Length]; // make a new array and copy all the values to it
		
		for (int i = 0; i<(historyBuffer.Length-1); i++) { // now we shift the array one slot to the right
			shiftingHistoryBuffer[i+1] = historyBuffer[i]; // and fill the empty slot with the new instant sound energy
		}
		
		shiftingHistoryBuffer [0] = e;
		
		for (int i = 0; i<historyBuffer.Length; i++) {
			historyBuffer[i] = shiftingHistoryBuffer[i]; //then we return the values to the original array
		}
		
		//float constant = 1.5f;

		if (e > (constant * E) &&  e < (constant * E + .008) ) { // now we check if we have a beat
			//cube.GetComponent<SpriteRenderer> ().color = Color.red;
	

	

						//cube.GetComponent<SpriteRenderer> ().color = Color.green;
						
						GameObject newCube = (GameObject)GameObject.Instantiate (blueCube);
						
						newCube.transform.position = new Vector3 (0, 0, 25.0f);
			
						newCube.transform.Translate (Random.Range (-10, 10), Random.Range (0, 10), 1.0f);
			
	
		
		}
		else if (e > (constant * E + 0.01) &&  e < (constant * E + .013) ) { // now we check if we have a beat
			//cube.GetComponent<SpriteRenderer> ().color = Color.red;
			
			
			
			
			//cube.GetComponent<SpriteRenderer> ().color = Color.green;
			
			GameObject newCube = (GameObject)GameObject.Instantiate (greenCube);
			
			newCube.transform.position = new Vector3 (0, 0, 30.0f);
			
			newCube.transform.Translate (Random.Range (-10, 10), Random.Range (0, 10), 1.0f);
			
			
			
		}
		else if (e > (constant * E + 0.013) &&  e < (constant * E + .014) ) { // now we check if we have a beat
			//cube.GetComponent<SpriteRenderer> ().color = Color.red;
			
			
			
			
			//cube.GetComponent<SpriteRenderer> ().color = Color.green;
			
			GameObject newCube = (GameObject)GameObject.Instantiate (redCube);
			
			newCube.transform.position = new Vector3 (0, 0, 35.0f);
			
			newCube.transform.Translate (Random.Range (-10, 10), Random.Range (0, 10), 1.0f);
			
			
			
		}




		else {
			cube.GetComponent<SpriteRenderer> ().color = Color.yellow;
		
		}
		/*
		Debug.Log ("Avg local: " + E);
		Debug.Log ("Instant: " + e);
		Debug.Log ("History Buffer: " + historybuffer());
		
		Debug.Log ("sum Variance: " + sumV);
		Debug.Log ("Variance: " + V);
		Debug.Log ("Constant: " + constant);

		Debug.Log ("--------");
*/Debug.Log (E +" - "+ e);

	}

	
	float sumStereo(float[] channel1, float[] channel2) {
		float e = 0;
		for (int i = 0; i<channel1.Length; i++) {
			e += ((channel1[i]*channel1[i]) + (channel2[i]*channel2[i]));
		}
		
		return e;
	}

	IEnumerator MyMethod() {
		Debug.Log("Before Waiting 2 seconds");
		yield return new WaitForSeconds(2);
		Debug.Log("After Waiting 2 Seconds");
	}
	float sumLocalEnergy() {
		float E = 0;
		
		for (int i = 0; i<historyBuffer.Length; i++) {
			E += historyBuffer[i]*historyBuffer[i];
		}
		
		return E;
	}
	
	string historybuffer() {
		string s = "";
		for (int i = 0; i<historyBuffer.Length; i++) {
			s += (historyBuffer[i] + ",");
		}
		return s;
	}
}