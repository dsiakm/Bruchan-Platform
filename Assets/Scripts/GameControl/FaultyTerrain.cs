using UnityEngine;
using System.Collections;

public class FaultyTerrain : MonoBehaviour {

	public float breakTime, returnTime;
	bool breakTerrain, restoreTerrain;
	float timeBreak, timeReturn;
	void Start () {
		timeBreak = 0; timeReturn = 0;
		breakTerrain = false;
		restoreTerrain = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (breakTerrain){
			timeBreak += Time.deltaTime;
			if (timeBreak > breakTime){
				GetComponent<SpriteRenderer>().enabled = false;
				GetComponent<BoxCollider2D> ().enabled = false;
				breakTerrain = false;
				restoreTerrain = true;
				timeReturn = 0;
				timeBreak = 0;
			}
		}else if(restoreTerrain){
			timeReturn += Time.deltaTime;
			if(timeReturn > returnTime){
				GetComponent<SpriteRenderer>().enabled = true;
				GetComponent<BoxCollider2D> ().enabled = true;
				restoreTerrain = false;
				timeReturn = 0;
				timeBreak = 0;
			}
		}
		
	}

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			breakTerrain = true;
		}
	}
}
