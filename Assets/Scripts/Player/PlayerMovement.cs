using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//Internal Control
	[SerializeField]
	bool isOnGround, canDash, isOnWallControl, jumpAgain, isRunning, isHitJumping;
	bool isOnWall{
		get{
			return isOnWallControl && !isOnGround;
		}
	}
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
		HitJump ();
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

		if(jump && isOnGround){
			rb2d.velocity = new Vector2(rb2d.velocity.x,PlayerState.playerState.JumpForce);
			timer = 0;
		}else if (jump && jumpAgain && !isOnGround && !isOnWall){
			rb2d.velocity = new Vector2(rb2d.velocity.x,PlayerState.playerState.JumpForce);
			jumpAgain = false;
			timer = 0;
		}else if(jump && isOnWall){
			float horizontal = Input.GetAxis ("Horizontal");
			if (horizontal == 0)
				rb2d.velocity = new Vector2 (PlayerState.playerState.JumpForce, PlayerState.playerState.JumpForce);
			else {
				if (horizontal < 0)
					horizontal = -1;
				else
					horizontal = 1;
				rb2d.velocity = new Vector2(PlayerState.playerState.JumpForce*-horizontal,PlayerState.playerState.JumpForce);
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

		if(isOnWall){
			rb2d.velocity = new Vector2 (rb2d.velocity.x/2, PlayerState.playerState.WallGrav);
		}
	}

	void Dash(){
		bool dash = Input.GetButtonDown ("Fire3");

		if (dash && canDash) {
			dashTimer = 0;
			rb2d.velocity = new Vector2 (PlayerState.playerState.DashSpeed*PlayerState.playerState.Facing,0);
			if (!isOnGround)
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

	void OnCollisionEnter2D(Collision2D collided){
		StaticTerrain st = collided.transform.GetComponent<StaticTerrain> ();
		if (st != null) {
			if (st.isGround) {
				isOnGround = true;
				jumpAgain = true;
				canDash = true;
			}else if(st.isWall){
				isOnWallControl = true;
				wallTimer = 0;
				rb2d.velocity = Vector2.zero;
				jumpAgain = true;
				canDash = true;
			}
		}
	}

	void OnCollisionExit2D(Collision2D collided){
		StaticTerrain st = collided.transform.GetComponent<StaticTerrain> ();
		if (st != null) {
			if (st.isGround) {
				isOnGround = false;				
			} else if (st.isWall) {
				isOnWallControl = false;
			}
		}
	}

	float addRunning(){
		if (isRunning)
			return PlayerState.playerState.RunningSpeed;
		return 0;
	}
}
