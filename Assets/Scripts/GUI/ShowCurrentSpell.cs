using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowCurrentSpell : MonoBehaviour {

	Image image;
	public Sprite basicSpell, fireSpell;

	void Start () {
		image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {

		string spell = PlayerState.playerState.GetActiveSpell();

		if (spell == "basicSpell"){
			image.sprite = basicSpell;
		}else if (spell == "fireSpell"){
			image.sprite = fireSpell;
		}
	}
}
