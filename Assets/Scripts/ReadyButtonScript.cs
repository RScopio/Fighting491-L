using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour {
	public int sceneIndex;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TransitionToFightingScene(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);

	}
}
