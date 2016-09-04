using UnityEngine;
using System.Collections;

public class SludgePoolBehaviour : MonoBehaviour {

	float time;
	public float duration;
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if (time > duration) {
			Destroy (gameObject);
		}
	}
}
