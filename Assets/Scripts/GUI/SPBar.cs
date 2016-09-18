using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SPBar : MonoBehaviour {

	Image image;

	void Start () {
		image = GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		image.fillAmount = PlayerState.playerState.currentSP / PlayerState.playerState.maxSP;
	}
}
