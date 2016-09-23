using UnityEngine;
using System.Collections;

public class ProjectileFaceHero : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 dir = PlayerState.playerState.transform.position - transform.position;
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
