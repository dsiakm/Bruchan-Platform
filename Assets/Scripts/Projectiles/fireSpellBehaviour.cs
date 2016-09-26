using UnityEngine;
using System.Collections;

public class fireSpellBehaviour : MonoBehaviour {

	CircularMovement cm;
	void Start () {
		cm = GetComponent<CircularMovement> ();
		cm.SetOrigen (PlayerState.playerState.gameObject.transform);


	}

	// Update is called once per frame
	void Update () {
		if (cm.GetTime() > 12f) {
			Destroy (gameObject);
		}
	}
}