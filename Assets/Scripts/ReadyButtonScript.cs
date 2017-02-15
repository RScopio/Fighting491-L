using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour {
	
	private SceneInfo sceneInfo;


	public void TransitionToFightingScene(){
        sceneInfo = GameObject.Find ("GameController").GetComponent<SceneInfo>();
        sceneInfo.TransitionToScene ("battle");

	}
}
