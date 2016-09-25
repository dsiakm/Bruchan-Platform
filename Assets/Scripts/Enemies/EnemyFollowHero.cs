using UnityEngine;
using System.Collections;

public class EnemyFollowHero : MonoBehaviour {

	Rigidbody2D rb2d;
	Transform playerTransform;
	Vector3 origin;
	public bool isFlying;
	public float minimumDistance;
	public float boundLeft, boundRight;
	public float speed;

	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		playerTransform = PlayerState.playerState.transform;
		origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Return Update in case is too far away
		float temp;
		if (transform.position.x < playerTransform.position.x) {
			temp = playerTransform.position.x - transform.position.x;
		} else if (transform.position.x >= playerTransform.position.x) {
			temp = transform.position.x - playerTransform.position.x;
		} else
			temp = 0;
		if (temp > minimumDistance) {
			rb2d.velocity = Vector2.zero;
			transform.position = Vector2.MoveTowards ( transform.position, origin, speed*Time.deltaTime);	
			return;
		}
		if (transform.position.y < playerTransform.position.y) {
			temp = playerTransform.position.y - transform.position.y;
		} else if (transform.position.y >= playerTransform.position.y) {
			temp = transform.position.y - playerTransform.position.y;
		} else
			temp = 0;
		if (temp > minimumDistance){
			rb2d.velocity = Vector2.zero;
			transform.position = Vector2.MoveTowards ( transform.position, origin, speed*Time.deltaTime);
			return;
		}

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
		if (isFlying){
			if (rb2d.position.y < playerTransform.position.y - 3) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, speed);
			} else if (rb2d.position.y > playerTransform.position.y + 3) {
				rb2d.velocity = new Vector2 (rb2d.velocity.x, -speed);
			}
		}
	}
}
