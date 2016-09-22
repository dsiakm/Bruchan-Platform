using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StageState : MonoBehaviour {

	public static StageState stageState;

	public string stageName;

	public Vector2 checkPoint;

	void Awake () {
		if (stageState == null) {
			DontDestroyOnLoad (gameObject);	
			stageState = this;
		} else if (stageState != this) {
			Destroy (gameObject);
		}
		checkPoint = new Vector2 (-6,11);
		stageName = "NewTestScenario";
	}

	void Start () {
		
	}
	
	public void PlayerDied(){
		SceneManager.LoadScene (stageName);
		PlayerState.playerState.transform.position = checkPoint;
		PlayerState.playerState.SetHP (-999,"none");
	}
}
