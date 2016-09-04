using UnityEngine;
using System.Collections;

public class EnemyKeepAway : MonoBehaviour {

	public float distance, startMoving;
	public bool keepDistance;
	Rigidbody2D rb2d;
	Transform playerTransform;

	float time;

	void Start () {
		time = 0;
		rb2d = GetComponent<Rigidbody2D> ();
		playerTransform = PlayerState.playerState.transform;
	}
	
	// Update is called once per frame
	void Update () {

		if(time < startMoving){
			time += Time.deltaTime;
			return;
		}
			
		float vct2Distance = Vector2.Distance ( new Vector2 (rb2d.position.x, playerTransform.position.y/2), playerTransform.position);

		if (rb2d.position.x < playerTransform.position.x && vct2Distance < distance) {
			rb2d.velocity = new Vector2 (-10, rb2d.velocity.y);
		} else if (rb2d.position.x > playerTransform.position.x && vct2Distance < distance) {
			rb2d.velocity = new Vector2 (10, rb2d.velocity.y);
		} else {
			//Debug.Log ("Cima");
			//rb2d.velocity = new Vector2 (0,rb2d.velocity.y);
			//time = 0;
		}
		if (keepDistance) {
			if(vct2Distance > distance+0.5f && vct2Distance < distance+1){
				Debug.Log ("Baixo");
				rb2d.velocity = new Vector2 (0,rb2d.velocity.y);
				time = 0;
			}else if (rb2d.position.x < playerTransform.position.x && vct2Distance > distance+1){
				rb2d.velocity = new Vector2(10, rb2d.velocity.y);
			}else if (rb2d.position.x > playerTransform.position.x && vct2Distance > distance+1){
				rb2d.velocity = new Vector2(-10, rb2d.velocity.y);
			}
		}
	}
}
