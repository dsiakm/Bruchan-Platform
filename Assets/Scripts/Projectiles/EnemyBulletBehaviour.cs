using UnityEngine;
using System.Collections;

public class EnemyBulletBehaviour : MonoBehaviour {

	public float speed;

	Vector2 destiny;

	void Start () {
		destiny = PlayerState.playerState.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.MoveTowards ( transform.position, destiny, speed*Time.deltaTime);
		if (transform.position.x == destiny.x && transform.position.y == destiny.y){
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D(Collision2D collided){
		if (collided.gameObject.tag != "Enemy"){
			Destroy (gameObject);
		}
	}
}
