using UnityEngine;
using System.Collections;

public class StaticTerrain : MonoBehaviour {

	public bool isGround, isWall, isRoof;

	MovementModifier mm;

	void Start () {
		mm = GetComponent<MovementModifier> ();
	}
	
	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			mm.SetMovementModification ();
		}
	}
}
