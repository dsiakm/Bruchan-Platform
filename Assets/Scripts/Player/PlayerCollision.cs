using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collided){

		if (PlayerState.playerState.IsInvulnerable()) {
			return;
		}

		Damage dmg = collided.gameObject.GetComponent<Damage> ();
		if (dmg != null){
			PlayerState.playerState.IsHit = dmg.hitJump;
			PlayerState.playerState.SetInvulnerable (dmg.procInvulnerability);
			PlayerState.playerState.SetHP (dmg.damage, dmg.element);
		}
	}
}
