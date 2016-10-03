using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour {

	public void changeScene (string input)
    {
        SceneManager.LoadScene(input);
    }
}
