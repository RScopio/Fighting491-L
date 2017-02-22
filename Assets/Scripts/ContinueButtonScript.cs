using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ContinueButtonScript : MonoBehaviour {

    public void TransitionToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}


