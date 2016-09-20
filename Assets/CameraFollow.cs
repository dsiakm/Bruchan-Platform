using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform lookAt;
	public Transform camTransform;

	Camera cam;

	public float distance = 10.0f;

	void Awake(){
		camTransform = transform;
		cam = Camera.main;

	}

	public void setLookAt(Transform look){
		lookAt = look;
		//currentX = 45f; currentY = 45f;
	}

	void Update(){

		cam.orthographicSize += 5*Input.GetAxis ("Mouse ScrollWheel");
		if(cam.orthographicSize < 0.1f){
			cam.orthographicSize = 0.1f;
		}
	}

	void LateUpdate(){
		Vector3 dir = new Vector3 (0,0	,-distance);
		camTransform.position = lookAt.position + dir;
	}
}
