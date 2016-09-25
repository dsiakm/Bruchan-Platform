using UnityEngine;
using System.Collections;

public class DestroyIfPastCheckPoint : MonoBehaviour {


	public int CheckPoint;

	void Start () {

		if (StageState.stageState == null || StageState.stageState.CPList.Count == 0){
			return;
		}

		if( StageState.stageState.CPList[CheckPoint] ){
			Destroy (gameObject);
		}
	}
}
