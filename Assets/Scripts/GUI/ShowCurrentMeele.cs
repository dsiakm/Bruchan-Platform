using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowCurrentMeele : MonoBehaviour {

	Image image;
	public Sprite basicWeapon;

	void Start () {
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		string weapon = PlayerState.playerState.GetActiveWeapon ();

		if (weapon == "basicWeapon"){
			image.sprite = basicWeapon;
		}
	}
}
