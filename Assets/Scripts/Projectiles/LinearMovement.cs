using UnityEngine;
using System.Collections;

public class LinearMovement : MonoBehaviour {


	public Transform origen;
	Vector2 origenFix;
	public bool backTrack;
	public float maxRangeX, minRangeX, maxRangeY, minRangeY, delayAtMax, delayAtMin, speedX, speedY, speedBX, speedBY;

	bool isOverX, isOverY;
	public bool IsOver{
		get{
			return isOverX && isOverY; 
		}
	}
	int backTrackCon;

	[SerializeField]
	float offX, offY, delay;
	void Start () {

		if (origen == null) {
			origen = gameObject.transform;
		}
		origenFix.x = origen.transform.position.x; origenFix.y = origen.transform.position.y;

		isOverX = false; isOverY = false;
		backTrackCon = 1;
		delay = 99;
	}
	

	void Update () {

		if( (delay < delayAtMax && backTrackCon == -1) ||
			delay < delayAtMin && backTrackCon == 1){
			delay += Time.deltaTime;
			return;
		}

		transform.position = new Vector2 (origenFix.x + offX, 
			origenFix.y + offY);

		if (backTrack) {
			if (backTrackCon == 1) {
				if (offX < maxRangeX) {
					offX += Time.deltaTime * speedX * backTrackCon;
				}
				if (offY < maxRangeY) {
					offY += Time.deltaTime * speedY * backTrackCon;
				}

				if (offX >= maxRangeX && offY >= maxRangeY) {
					backTrackCon = -1;
					delay = 0;
				}
			} else {
				if (offX > minRangeX) {
					offX += Time.deltaTime * speedBX * backTrackCon;
				}
				if (offY > minRangeY) {
					offY += Time.deltaTime * speedBY * backTrackCon;
				}

				if (offX <= minRangeX && offY <= minRangeY) {
					backTrackCon = 1;
					delay = 0;
				}
			}
		} else {
			if ( (offX < maxRangeX && maxRangeX !=0) || (minRangeX < offX && minRangeX !=0) ) {
				offX += Time.deltaTime * speedX * backTrackCon;
			} else
				isOverX = true;
			if ( (offY < maxRangeY && maxRangeY !=0) || (minRangeY < offY && minRangeY !=0) ) {
				offY += Time.deltaTime * speedY * backTrackCon;
			} else
				isOverY = true;
		}	

		
	}

	public void SetOrigen(Transform transform){
		origen = transform;
		origenFix.x = origen.transform.position.x; origenFix.y = origen.transform.position.y;
	}
	public void SetFacing(int face){
		backTrackCon = face;
	}
}
