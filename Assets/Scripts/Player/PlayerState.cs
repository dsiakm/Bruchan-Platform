using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	//Initialization section
	public static PlayerState playerState;

	void Awake () {
		if (playerState == null) {
			DontDestroyOnLoad (gameObject);	
			playerState = this;
		}else if (playerState != this){
			Destroy (gameObject);
		}

		InitializeVariables ();
	}

	void InitializeVariables(){
		activeWeapon = "basicWeapon";
		activeSpell = "basicSpell";
		activeItem = "basicItem";

		invulnerability = false;
		baseHP = 100;
		modHP = 0;
		currentHP = maxHP;
		baseSP = 100;
		modSP = 0;
		currentSP = maxSP;

		facing = 1;
		SetMovementToDefault ();
		WallTimeMin = wallTimeMinDEFAULT;
		DashTimeMin = dashTimerMinDEFAULT;
	}


	//Player's Items & Magic section
	string activeWeapon;
	string activeSpell;
	string activeItem;
	string activeElement;

	public string GetActiveWeapon(){
		return activeWeapon;
	}
	public string GetActiveSpell(){
		return activeSpell;
	}
	public string GetActiveItem(){
		return activeItem;
	}
	public void ChangeActiveWeapon(float axis){
		int side;
		if (axis < 0) {
			side = -1;
		} else
			side = 1;
		activeWeapon = GameState.gameState.CicleUnlockedWeapons (side);
	}
	public void ChangeActiveSpell(float axis){
		int side;
		if (axis < 0) {
			side = -1;
		} else
			side = 1;
		activeSpell = GameState.gameState.CicleUnlockedSpells (side);
	}
	public void ChangeActiveItem(float axis){
		int side;
		if (axis < 0) {
			side = -1;
		} else
			side = 1;
		activeItem = GameState.gameState.CicleUnlockedItems (side);
	}

	//HP control section
	public float baseHP, modHP, currentHP, baseSP, modSP, currentSP;
	public float maxHP{
		get{ return baseHP + modHP; }
	}
	public float maxSP{
		get { return baseSP + modSP; }
	}
	public bool isDead{
		get{ 
			if (currentHP < 0) {
				return true;
			} else
				return false;
		}
	}
	bool invulnerability;
	string currentElement;

	public void SetHP(float damage, string element){
		damage *= DefineElementalMod (element);
		currentHP -= damage;
		if (isDead) {
			StageState.stageState.PlayerDied ();
		} else if (currentHP > maxHP)
			currentHP = maxHP;
	}
	public void SetSP(float loss){
		currentSP -= loss;
		if (currentSP > maxSP)
			currentSP = maxSP;
	}
	public float GetHP(){
		return currentHP;
	}
	public void SetModHP(float mod){
		modHP = mod;
	}


	float DefineElementalMod(string element){
		return 1;
	}

	public void SetInvulnerable(bool boolean){
		invulnerability = boolean;
	}
	public bool IsInvulnerable(){
		return invulnerability;
	}



	//Movement Control Section

	//Ment to be changed
	float desaceleration, moveSpeed, jumpForce, jumpExtraForce, jumpExtraTime, runningSpeed, dashSpeed, wallGrav; 
	//Not ment to be changed but could
	float wallTimeMin, dashTimeMin;
	//Default Values for movement
	const float desacelerationDEFAULT = 0.95f, 
				moveSpeedDEFAULT = 10f, 
				jumpForceDEFAULT = 8, 
				jumpExtraForceDEFAULT = 8, 
				jumpExtraTimeDEFAULT = 0.3f, 
				runningSpeedDEFAULT = 8, 
				dashSpeedDEFAULT = 32, 
				wallGravDEFAULT = -8;
	const float wallTimeMinDEFAULT = 0.3f, 
				dashTimerMinDEFAULT = 0.3f;
	int facing;

	public void SetMovementToDefault(){
		desaceleration = desacelerationDEFAULT;
		moveSpeed = moveSpeedDEFAULT;
		jumpForce = jumpForceDEFAULT;
		jumpExtraForce = jumpExtraForceDEFAULT;
		jumpExtraTime = jumpExtraTimeDEFAULT;
		runningSpeed = runningSpeedDEFAULT;
		dashSpeed = dashSpeedDEFAULT;
		wallGrav = wallGravDEFAULT;
	}

	public float Desaceleration {
		get {
			return this.desaceleration;
		}
		set {
			desaceleration = value;
		}
	}
	public float MoveSpeed {
		get {
			return this.moveSpeed;
		}
		set {
			moveSpeed = value;
		}
	}

	public float JumpForce {
		get {
			return this.jumpForce;
		}
		set {
			jumpForce = value;
		}
	}

	public float JumpExtraForce {
		get {
			return this.jumpExtraForce;
		}
		set {
			jumpExtraForce = value;
		}
	}

	public float JumpExtraTime {
		get {
			return this.jumpExtraTime;
		}
		set {
			jumpExtraTime = value;
		}
	}

	public float RunningSpeed {
		get {
			return this.runningSpeed;
		}
		set {
			runningSpeed = value;
		}
	}

	public float DashSpeed {
		get {
			return this.dashSpeed;
		}
		set {
			dashSpeed = value;
		}
	}

	public float WallGrav {
		get {
			return this.wallGrav;
		}
		set {
			wallGrav = value;
		}
	}

	public float WallTimeMin {
		get {
			return this.wallTimeMin;
		}
		set {
			wallTimeMin = value;
		}
	}

	public float DashTimeMin {
		get {
			return this.dashTimeMin;
		}
		set {
			dashTimeMin = value;
		}
	}
	public int Facing {
		get {
			return this.facing;
		}
		set {
			facing = value;
		}
	}

	//SPECIAL CONDITIONS SECTION
	bool isHolding, isClimbing, isHit;
	public bool IsHolding {
		get {
			return this.isHolding;
		}
		set {
			isHolding = value;
		}
	}

	public bool IsClimbing {
		get {
			return this.isClimbing;
		}
		set {
			isClimbing = value;
		}
	}
	public bool IsHit {
		get {
			return this.isHit;
		}
		set {
			isHit = value;
		}
	}

}
