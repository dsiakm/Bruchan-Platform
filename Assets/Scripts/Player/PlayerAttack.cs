using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	void Update(){
		MeleeAttack ();
		RangedAttack ();
		Change ();
		RecoverSP ();
	}

	void MeleeAttack(){
		if (Input.GetButtonDown("Fire1")){
			Instantiate (Resources.Load("ProjectilesPlayer/"+PlayerState.playerState.GetActiveWeapon()) as GameObject, gameObject.transform.position, Quaternion.identity);
		}
	}

	void RangedAttack(){
		if (Input.GetButtonDown("Fire2")){
			Instantiate (Resources.Load("ProjectilesPlayer/"+PlayerState.playerState.GetActiveSpell()) as GameObject, gameObject.transform.position, Quaternion.identity);
		}
	}

	void Change(){
		if(Input.GetButton("ChangeWeapon")){
			PlayerState.playerState.ChangeActiveWeapon (Input.GetAxis("ChangeWeapon"));
		}else if(Input.GetButton("ChangeSpell")){
			PlayerState.playerState.ChangeActiveSpell (Input.GetAxis("ChangeSpell"));
		}else if(Input.GetButton("ChangeItem")){
			PlayerState.playerState.ChangeActiveItem (Input.GetAxis("ChangeItem"));
		}
	}

	void RecoverSP(){
		PlayerState.playerState.SetSP (-1*Time.deltaTime);
	}
}
