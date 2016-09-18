using UnityEngine;
using System.Collections;

public class FaultyTerrain : MonoBehaviour {

	public float breakTime;
	bool breakTerrain;
	float time;
	void Start () {
		time = 0;
		breakTerrain = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (breakTerrain){
			time += Time.deltaTime;
			if (time > breakTime){
				Destroy (gameObject);
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			breakTerrain = true;
		}
	}
}
