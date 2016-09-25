using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class StageState : MonoBehaviour {

	public static StageState stageState;

	public string stageName;

	public Vector2 checkPoint;

	public List<bool> CPList = new List<bool>();

	void Awake () {
		if (stageState == null) {
			DontDestroyOnLoad (gameObject);	
			stageState = this;
		} else if (stageState != this) {
			Debug.Log ("Destroy");
			Destroy (gameObject);
		}
	}

	void Start () {
		for (int i = 0; i<10;i++){
			CPList.Add (false);
		}

		checkPoint = new Vector2 (-6,11);
		stageName = "NewTestScenario";
	}
	
	public void PlayerDied(){
		SceneManager.LoadScene (stageName);
		PlayerState.playerState.transform.position = checkPoint;
		PlayerState.playerState.SetHP (-999,"none");
	}
}
