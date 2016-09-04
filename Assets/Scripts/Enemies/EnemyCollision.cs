using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "PHaz") {
			Damage dmg = other.gameObject.GetComponent<Damage> ();
			EnemyState es = GetComponent<EnemyState> ();
			es.SetHP (dmg.damage, dmg.element);
		}
	}
}
