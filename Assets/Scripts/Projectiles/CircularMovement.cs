using UnityEngine;
using System.Collections;

public class CircularMovement : MonoBehaviour {

	public Transform origen;
	public bool reverse, backTrack, stopAtRange, movingRadius;
	public float radius, radiusMax, radiusMin,spinningRange, spinningSpeed, radiusSpeed, inicialAngle;

	[SerializeField]
	float time, radiusVar;
	int backTrackCon, radiusCon;
	Transform obTrans;

	void Start(){
		time = inicialAngle;
		backTrackCon = 1;
		radiusCon = 1;
		radiusVar = 0;
		if (spinningRange == 0)
			spinningRange = 2 * Mathf.PI;
		else
			spinningRange += inicialAngle;
	}

	void Update () {

		if (movingRadius) {
			if(radiusCon==1){
				radiusVar += Time.deltaTime*radiusSpeed;
				if (radiusVar > radiusMax)
					radiusCon = 2;
			}else if(radiusCon==2){
				radiusVar -= Time.deltaTime * radiusSpeed;
				if(radiusVar < radiusMin)
					radiusCon = 1;
			}
		}

		if (reverse) {
			transform.position = new Vector3 (origen.position.x + (radius + radiusVar) * Mathf.Sin (time * -1), 
				origen.position.y + (radius + radiusVar) * Mathf.Cos (time));
		} else {
			transform.position = new Vector3 	(origen.position.x + (radius+radiusVar) * Mathf.Sin(time), 
				origen.position.y + (radius+radiusVar) * Mathf.Cos (time));
		}

		

		if (backTrack) {
			if(backTrackCon==1){
				time += Time.deltaTime * spinningSpeed;
				if (time > spinningRange) {
					backTrackCon = 2;
				} 
			}else if(backTrackCon==2) {
				time -= Time.deltaTime * spinningSpeed;
				if (time < inicialAngle) {
					backTrackCon = 1;
				}
			}
		} else {
			if(time < spinningRange || !stopAtRange){
				time += Time.deltaTime*spinningSpeed;
			}
		}
	}

	public float GetTime(){
		return time;
	}
	public void SetOrigen(Transform transform){
		origen = transform;
	}
	public void SetFacing(bool reverse){
		this.reverse = reverse;
	}
}
