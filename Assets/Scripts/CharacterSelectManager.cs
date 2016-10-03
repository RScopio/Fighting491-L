using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
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

	public void TransitionToFightingScene(int sceneIndex){
		SceneManager.LoadScene (sceneIndex);
	
	}
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

//		if (Input.GetAxisRaw ("Horizontal") == 0 && Input.GetAxisRaw ("Vertical") == 0) {
//			
//			string tempSpriteName = selectedGameObject.GetComponent<Image> ().sprite.name;
//			foreach (KeyValuePair<string,string> name in GameManager.characters) {
//				
//				if (tempSpriteName == name.Value) {
//					Debug.Log (name.Key + " is inside " + tempSpriteName);
//					characterBackgroundPortait.sprite = Resources.Load<Sprite> ("Textures/streetfighterlargePortraits/" + name.Key);
//					break;
//				}
//			}
//		}
//		Debug.Log (Input.GetAxisRaw ("Horizontal")+ "" + Input.GetAxisRaw ("Vertical"));

	
	}


	private void OnDisable(){
		isSelected = false;
	}
}