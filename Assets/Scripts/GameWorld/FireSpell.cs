using UnityEngine;
using System.Collections;

public class FireSpell : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			GameState.gameState.AddSpell ("fireSpell");

			Destroy (gameObject);
		}
	}
}
