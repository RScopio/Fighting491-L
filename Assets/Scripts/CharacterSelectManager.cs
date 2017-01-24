using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.IO;

public class CharacterSelectManager : MonoBehaviour {


	public int sceneIndex;
	private Animator animator;

	public EventSystem eventSystem;
	public  Image characterSelectBox;
	public GameObject selectedGameObject;
	public Button[] characters;
	public GameObject readyButton;

	private Button selectedPlayer;

	private bool isSelected;
	private bool characterIsSelected;
	public Image characterBackgroundPortait;


	// Use this for initialization
	void Start () {
		
		animator = readyButton.GetComponentInParent<Animator> ();
		animator.SetBool ("isReady", false);
		characterIsSelected = false;
		eventSystem.SetSelectedGameObject (selectedGameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
		if (characterIsSelected) {
			
			return;
		}



	

		if (Input.GetAxisRaw ("StartButton") != 0 || Input.GetAxisRaw("PS4_X") != 0) {
			
			characterIsSelected = true;

			eventSystem.SetSelectedGameObject (readyButton);

			animator.SetBool ("isReady", true);
		}



	
	}


	private void OnDisable(){
		isSelected = false;
	}
}