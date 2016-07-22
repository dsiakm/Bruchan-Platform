using UnityEngine;
using System.Collections;

public class MovementModifier : MonoBehaviour {

	public bool isGrass;

	public void SetMovementModification(){
		if (isGrass){
			PlayerState.playerState.SetMovementToDefault ();
		}
	}
}
