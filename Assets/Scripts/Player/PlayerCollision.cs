using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	float invulnerableTrack;

	void Start(){
		invulnerableTrack = 0;
	}

	void Update(){
		if (invulnerableTrack < 1) {
			invulnerableTrack += Time.deltaTime;
		} else if(invulnerableTrack >= 1 && invulnerableTrack < 5) {
			invulnerableTrack = 99;
			PlayerState.playerState.SetInvulnerable (false);
		}
	}

	void OnCollisionEnter2D(Collision2D collided){
		
		if (PlayerState.playerState.IsInvulnerable()) {
			return;
		}

		Damage dmg = collided.gameObject.GetComponent<Damage> ();
		if (dmg != null){
			PlayerState.playerState.IsHit = dmg.hitJump;
			if (dmg.procInvulnerability) {
				PlayerState.playerState.SetInvulnerable (true);
				invulnerableTrack = 0;
			}
			PlayerState.playerState.SetHP (dmg.damage, dmg.element);
		}


	}
}
