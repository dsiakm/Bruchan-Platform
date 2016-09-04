using UnityEngine;
using System.Collections;

public class SlugdeSpawnBehaviour : MonoBehaviour {

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
			lm.maxRangeX = 6;
		else if (facing == -1)
			lm.minRangeX = -6;
		else if (facing == 2)
			lm.maxRangeY = 6;
		else if (facing == -2)
			lm.maxRangeY = -6;

	}

	// Update is called once per frame
	void Update () {
		if(lm.IsOver){

			Instantiate (Resources.Load("ProjectilesPlayer/SludgePool") as GameObject, gameObject.transform.position, Quaternion.identity);

			Destroy (gameObject);
		}
	}
}
