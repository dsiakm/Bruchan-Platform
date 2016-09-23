using UnityEngine;
using System.Collections;

public class Consumable : MonoBehaviour {

	public float HP;

	
	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			PlayerState.playerState.SetHP (-50,"none");

			Destroy (gameObject);
		}
	}
}
