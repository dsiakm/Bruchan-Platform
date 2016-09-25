using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {

	public int CPNumber;

	void Awake(){
		if ( StageState.stageState.CPList[CPNumber] ){
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag == "Player"){
			StageState.stageState.checkPoint = transform.position;

			StageState.stageState.CPList [CPNumber] = true;

			Destroy (gameObject);
		}
	}
}
