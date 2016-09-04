using UnityEngine;
using System.Collections;

public class CameraFocus : MonoBehaviour {

	public Transform character;
	public float speed = 3, xDifference, yDifference, movementThreshold = 3;
	Vector3 moveTemp;

	void Update(){

		if (character.position.x > transform.position.x) {
			xDifference = character.position.x - transform.position.x;
		} else {
			xDifference = transform.position.x - character.position.x;
		}

		if (character.position.y > transform.position.y) {
			yDifference = character.position.y - transform.position.y;
		} else {
			yDifference = transform.position.y - character.position.y;
		}

		if(xDifference >= movementThreshold || yDifference >= movementThreshold){
			moveTemp = character.position;
			moveTemp.z = -5;

			transform.position = Vector3.MoveTowards (transform.position, moveTemp, speed * Time.deltaTime);
		}


	}
}
