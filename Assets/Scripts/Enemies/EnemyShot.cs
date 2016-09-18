using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {

	public float frequence;
	public float minimumDistance;
	float time;
	Transform playerTransform;

	void Start(){
		playerTransform = PlayerState.playerState.transform;
	}


	void Update () {

		float temp;
		if (transform.position.x < playerTransform.position.x) {
			temp = playerTransform.position.x - transform.position.x;
		} else if (transform.position.x >= playerTransform.position.x) {
			temp = transform.position.x - playerTransform.position.x;
		} else
			temp = 0;
		if (temp > minimumDistance)
			return;
		if (transform.position.y < playerTransform.position.y) {
			temp = playerTransform.position.y - transform.position.y;
		} else if (transform.position.y >= playerTransform.position.y) {
			temp = transform.position.y - playerTransform.position.y;
		} else
			temp = 0;
		if (temp > minimumDistance)
			return;

		if (frequence < time) {
			time = 0;
			Instantiate (Resources.Load("ProjectilesEnemy/EnemyBullet") as GameObject, 
				gameObject.transform.position, Quaternion.identity);

		}

		time += Time.deltaTime;
	}
}
