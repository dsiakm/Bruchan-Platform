using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player") {
			collided.transform.SetParent (gameObject.transform);
		}
	}

	void OnCollisionExit2D(Collision2D collided){
		if (collided.gameObject.tag == "Player") {
			gameObject.transform.DetachChildren ();
		}
	}
}
