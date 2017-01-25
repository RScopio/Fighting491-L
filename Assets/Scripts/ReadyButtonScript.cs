using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour {
	
	private GameManager gameManager;


	public void TransitionToFightingScene(){
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		gameManager.TransitionToScene ("battle");

	}
}
