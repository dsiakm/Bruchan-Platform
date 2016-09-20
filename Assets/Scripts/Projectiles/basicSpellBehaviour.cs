using UnityEngine;
using System.Collections;

public class basicSpellBehaviour : MonoBehaviour {

	public float maxDistance;
	public float speed;
	LinearMovement lm;
	int facing;

	void Start () {
		lm = GetComponent<LinearMovement> ();
		int facing = PlayerState.playerState.Facing;

		if (facing == 1 || facing == 2)
			lm.SetFacing (1);
		else 
			lm.SetFacing(-1);

		lm.SetOrigen (PlayerState.playerState.gameObject.transform);
		if (facing == 1)
			lm.maxRangeX = maxDistance;
		else if (facing == -1)
			lm.minRangeX = -maxDistance;
		else if (facing == 2)
			lm.maxRangeY = maxDistance;
		else if (facing == -2)
			lm.maxRangeY = -maxDistance;

		lm.speedX = speed; lm.speedBX = speed;

	}
	
	// Update is called once per frame
	void Update () {
		if(lm.IsOver){
			Destroy (gameObject);
		}
	}
}
