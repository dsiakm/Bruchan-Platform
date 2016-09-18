using UnityEngine;
using System.Collections;

public class PlayerMovementImproved : MonoBehaviour {

	//NEW//
	bool isOnGround(){

		float lengthToSearch = 0.1f;
		float colliderThreshold = 0.001f;
		Renderer renderer = GetComponent<Renderer> ();

		Vector2 linestart = new Vector2 (this.transform.position.x, this.transform.position.y - renderer.bounds.extents.y - colliderThreshold);

		Vector2 vectorToSearch = new Vector2 (this.transform.position.x, linestart.y - lengthToSearch);

		RaycastHit2D hit = Physics2D.Linecast (linestart, vectorToSearch);

		return hit;

	}
	bool isWallOnLeft(){

		float lengthToSearch = 0.1f;
		float colliderThreshold = 0.01f;
		Renderer renderer = GetComponent<Renderer> ();
		 
		Vector2 linestart = new Vector2 (this.transform.position.x - renderer.bounds.extents.x - colliderThreshold, this.transform.position.y);
		Vector2 vectorToSearch = new Vector2 (linestart.x - lengthToSearch, this.transform.position.y);

		RaycastHit2D hitLeft = Physics2D.Linecast (linestart, vectorToSearch);

		return hitLeft;
	}
	bool isWallOnRight(){

		float lengthToSearch = 0.1f;
		float colliderThreshold = 0.01f;
		Renderer renderer = GetComponent<Renderer> ();

		Vector2 linestart = new Vector2 (this.transform.position.x + renderer.bounds.extents.x + colliderThreshold, this.transform.position.y);
		Vector2 vectorToSearch = new Vector2 (linestart.x + lengthToSearch, this.transform.position.y);

		RaycastHit2D hitRight = Physics2D.Linecast (linestart, vectorToSearch);

		return hitRight;
	}
	//NEW//


	//Internal Control
	[SerializeField]
	bool canDash, jumpAgain, isRunning, isHitJumping;

	float timer, wallTimer, dashTimer, isHitJumpingTimer;

	Rigidbody2D rb2d;

	void Awake(){
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update(){
		if (HitJumpLost ())
			return;
		SetAutomaticFacing ();
		MoveLeftRight ();
		Jump ();
		WallSlide ();
		HoldJump ();
		Dash ();
		ResetCharges ();
		HitJump ();
	}

	void ResetCharges(){
		if (isOnGround() || isWallOnLeft() || isWallOnRight() ){
			jumpAgain = true;
			canDash = true;
		}
	}

	bool HitJumpLost(){
		if (isHitJumping){
			isHitJumpingTimer += Time.deltaTime;
			if(isHitJumpingTimer>0.5f){
				isHitJumping = false;
			}
			return true;
		}
		dashTimer = 99;
		return false;
	}

	void MoveLeftRight(){
		float horizontal = Input.GetAxis ("Horizontal");

		if(wallTimer <= PlayerState.playerState.WallTimeMin){
			return;
		}

		if(dashTimer < PlayerState.playerState.DashTimeMin){
			rb2d.velocity = new Vector2 (PlayerState.playerState.DashSpeed*PlayerState.playerState.Facing, 0);
			return;
		}

		if (horizontal < -0.1f) {
			rb2d.velocity = new Vector2 (-PlayerState.playerState.MoveSpeed - addRunning(), rb2d.velocity.y);
		} else if (horizontal > 0.1f) {
			rb2d.velocity = new Vector2 (PlayerState.playerState.MoveSpeed + addRunning(), rb2d.velocity.y);
		} else if (horizontal == 0) {
			rb2d.velocity = Vector2.Lerp (new Vector2 (0, rb2d.velocity.y) , new Vector2 (rb2d.velocity.x, rb2d.velocity.y), PlayerState.playerState.Desaceleration );
		}
	}

	void Jump(){
		bool jump = Input.GetButtonDown("Jump");

		if(jump && isOnGround()){
			rb2d.velocity = new Vector2(rb2d.velocity.x,PlayerState.playerState.JumpForce);
			timer = 0;
		}else if (jump && jumpAgain && !isOnGround() && !isWallOnLeft() && !isWallOnRight() ){
			rb2d.velocity = new Vector2(rb2d.velocity.x,PlayerState.playerState.JumpForce);
			jumpAgain = false;
			timer = 0;
		}else if(jump && (isWallOnLeft() || isWallOnRight()) ){

			if (isWallOnLeft()) {
				rb2d.velocity = new Vector2 (PlayerState.playerState.JumpForce, PlayerState.playerState.JumpForce);
			} else {
				rb2d.velocity = new Vector2 (PlayerState.playerState.JumpForce*-1, PlayerState.playerState.JumpForce);
			}

			wallTimer = 0;
			timer = 0;
		}

		wallTimer += Time.deltaTime;
	}

	void HoldJump(){

		bool jump = Input.GetButton ("Jump");

		if (jump && timer < PlayerState.playerState.JumpExtraTime) {
			rb2d.velocity = new Vector2 (rb2d.velocity.x, PlayerState.playerState.JumpExtraForce);
		}

		timer += Time.deltaTime;
	}

	void WallSlide(){

		if(wallTimer < PlayerState.playerState.WallTimeMin){
			return;
		}

		if( isWallOnLeft() || isWallOnRight() ){
			rb2d.velocity = new Vector2 (rb2d.velocity.x/2, PlayerState.playerState.WallGrav);
		}
	}

	void Dash(){
		bool dash = Input.GetButtonDown ("Fire3");

		if (dash && canDash) {
			dashTimer = 0;
			rb2d.velocity = new Vector2 (PlayerState.playerState.DashSpeed*PlayerState.playerState.Facing,0);
			if (!isOnGround())
				canDash = false;
		}
		isRunning = Input.GetButton ("Fire3");

		dashTimer += Time.deltaTime;
	}

	void SetAutomaticFacing(){
		float horizontal = Input.GetAxis ("Horizontal");
		if (horizontal < 0) {
			PlayerState.playerState.Facing = -1;
		} else if (horizontal > 0) {
			PlayerState.playerState.Facing = 1;
		} else {
			if(rb2d.velocity.x < -0.5f){
				PlayerState.playerState.Facing = -1;
			}else if(rb2d.velocity.x > 0.5f){
				PlayerState.playerState.Facing = 1;
			}
		}
	}

	void HitJump(){
		if(PlayerState.playerState.IsHit){
			rb2d.velocity = new Vector2 (5*-PlayerState.playerState.Facing,5);
			PlayerState.playerState.IsHit = false;
			isHitJumping = true;
			isHitJumpingTimer = 0;
		}

	}

	float addRunning(){
		if (isRunning)
			return PlayerState.playerState.RunningSpeed;
		return 0;
	}
}
