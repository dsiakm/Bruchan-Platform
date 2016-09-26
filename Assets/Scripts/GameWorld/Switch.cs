using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

	public GameObject go;

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			go.SetActive (true);

			Destroy (gameObject);
		}
	}
}
