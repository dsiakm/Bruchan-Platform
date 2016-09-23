using UnityEngine;
using System.Collections;

public class DestroyIfPastCheckPoint : MonoBehaviour {


	public int CheckPoint;

	void Start () {
		if( StageState.stageState.CPList[CheckPoint] ){
			Debug.Log ("hOI");
			Destroy (gameObject);
		}
	}
}
