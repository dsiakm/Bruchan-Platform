using UnityEngine;
using System.Collections;

public class MovementModifier : MonoBehaviour {

	public bool isGrass, isIce;

	public void SetMovementModification(){
		if (isGrass){
			PlayerState.playerState.SetMovementToDefault ();
		} else if (isIce){
			PlayerState.playerState.SetMovementToDefault ();
			PlayerState.playerState.Desaceleration = 1;
		}
	}
}
