using UnityEngine;
using System.Collections;

public class basicWeaponBehaviour : MonoBehaviour {

	CircularMovement cm;
	void Start () {
		cm = GetComponent<CircularMovement> ();
		cm.SetOrigen (PlayerState.playerState.gameObject.transform);

		if (PlayerState.playerState.Facing == 1)
			cm.SetFacing (false);
		else
			cm.SetFacing (true);

	}
	
	// Update is called once per frame
	void Update () {
		if (cm.GetTime() > 3.14f) {
			Destroy (gameObject);
		}
	}
}
