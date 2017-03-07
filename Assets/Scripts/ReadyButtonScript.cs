using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour {
	
	private SceneInfo sceneInfo;


	public void TransitionToStageSelect(){
        sceneInfo = GameObject.Find ("GameController").GetComponent<SceneInfo>();
        sceneInfo.TransitionToScene ("Stageselect");

	}

    public void TransitionToFightScene()
    {
        sceneInfo = GameObject.Find("GameController").GetComponent<SceneInfo>();
        sceneInfo.TransitionToScene("battle");
    }
}
