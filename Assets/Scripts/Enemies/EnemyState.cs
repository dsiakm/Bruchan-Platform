using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour {

	int facing;
	public string enemyElement;

	public int Facing{
		get{
			return facing;
		}
		set{
			facing = value;
		}
	}

	public float maxHP, currentHP;

	public bool IsDead{
		get{
			if (currentHP <= 0)
				return true;
			else
				return false;
		}
	}


	void Start () {
		facing = 1;
		currentHP = maxHP;
	}

	public void SetHP(float damage, string element){
		damage *= DefineElementalModE (element);
		currentHP -= damage;
		if (IsDead) {
			Destroy (gameObject);
		} else if (currentHP > maxHP)
			currentHP = maxHP;
	}

	public float DefineElementalModE(string element){

		if(enemyElement == "FIRE"){
			if (element == "water") {
				return 1;
			} else {
				return 0;
			}
		}else if (enemyElement == "fire"){
			if (element == "fire") {
				return 0;
			} else if (element == "water") {
				return 1.5f;
			} else {
				return 0;
			}
		}

		return 1;
	}
}
