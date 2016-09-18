using UnityEngine;
using System.Collections;

public class BlazeMovement : MonoBehaviour {

	public bool isHorizontal, isVertical;
	public float range, speed, timeStill, timeOff;

	bool shrink;
	float time, timeTemp;

	void Start () {
		shrink = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time < timeOff) {
			return;
		}

		if (isHorizontal){
			if (!shrink) {
				transform.localScale += new Vector3 (speed * Time.deltaTime, 0, 0);
			} else if (shrink && time > timeTemp+timeStill) {
				transform.localScale -= new Vector3 (speed * Time.deltaTime, 0, 0);
				if (transform.localScale.x <= 0){
					time = 0;
					shrink = false;
				}
			}

			if (transform.localScale.x > range && !shrink){
				shrink = true;
				timeTemp = time;
			}

		}else if(isVertical){
			if (!shrink) {
				transform.localScale += new Vector3 (0, speed * Time.deltaTime, 0);
			} else if (shrink && time > timeTemp+timeStill) {
				transform.localScale -= new Vector3 (0, speed * Time.deltaTime, 0);
				if (transform.localScale.y <= 0){
					time = 0;
					shrink = false;
				}
			}

			if (transform.localScale.y > range && !shrink){
				shrink = true;
				timeTemp = time;
			}
		}
	}
}
