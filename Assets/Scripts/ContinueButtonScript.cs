using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ContinueButtonScript : MonoBehaviour {

    public void TransitionToScene(int sceneIndex)
    { SceneManager.LoadScene(sceneIndex);

    }
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}


