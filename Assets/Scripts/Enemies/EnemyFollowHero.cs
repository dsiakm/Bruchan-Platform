﻿using UnityEngine;
using System.Collections;

public class EnemyFollowHero : MonoBehaviour {

	Rigidbody2D rb2d;
	Transform playerTransform;
	public float minimumDistance;
	public float boundLeft, boundRight;
	public float speed;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerTransform = PlayerState.playerState.transform;
	}
	
	// Update is called once per frame
	void Update () {
		//Return Update in case is too far away
		float temp;
		if (rb2d.position.x < playerTransform.position.x) {
			temp = playerTransform.position.x - rb2d.position.x;
		} else if (rb2d.position.x >= playerTransform.position.x) {
			temp = rb2d.position.x - playerTransform.position.x;
		} else
			temp = 0;
		if (temp > minimumDistance)
			return;

		//Return in case is close to the bound
		if(boundLeft >= rb2d.transform.position.x && boundLeft != 0){
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
			return;
		}else if (boundRight <= rb2d.transform.position.x && boundRight != 0){
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
			return;
		}

		//Move towards Player
		if (rb2d.position.x < playerTransform.position.x - 1) {
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		} else if (rb2d.position.x > playerTransform.position.x + 1) {
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
		}
	}
}