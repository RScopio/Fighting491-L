using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;

public class CharacterSelectionAction : MonoBehaviour,IPointerEnterHandler, ISelectHandler{
	public string character;
	private GameManager gameManager;
	public EventSystem eventsystem;
	public Image characterBackgroundPortait;

	public void start(){
		
	}
	public void update(){
		
	}

	public void OnPointerEnter(PointerEventData eventData){
//		foreach (KeyValuePair<string,string> name in GameManager.characters) {
//			//Debug.Log (name.Value + " is inside " + gameObject.GetComponent<Image>().sprite.name);
//			if (gameObject.GetComponent<Image>().sprite.name == name.Value) {
//				Debug.Log (name.Key + " is inside " + gameObject.GetComponent<Image>().sprite.name);
//				Sprite tempSprite = Resources.Load<Sprite> ("Textures/streetfighterlargePortraits/" + name.Key);
//				characterBackgroundPortait.sprite = tempSprite;
//				break;
//			}
//		}

			

	}

	public void OnSelect(BaseEventData eventData){
		Debug.Log ("awesome");
		foreach (KeyValuePair<string,string> name in GameManager.characters) {
			Debug.Log ( gameObject.GetComponent<Image>().sprite.name +" is inside " + name.Value);
			if (gameObject.GetComponent<Image>().sprite.name == name.Value) {
				//Debug.Log (name.Key + " is inside " + gameObject.GetComponent<Image>().sprite.name);
				Sprite tempSprite = Resources.Load<Sprite> ("Textures/streetfighterlargePortraits/" + name.Key);
				characterBackgroundPortait.sprite = tempSprite;
				break;
			}
		}

	}

	public void SelectedCharacter(){
		

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		character = gameObject.GetComponent<Image> ().sprite.name;
		var colors = this.GetComponent<Button> ().colors;
		colors.normalColor = Color.gray;
		colors.highlightedColor = Color.gray;
		GetComponent<Button> ().colors = colors;

		gameManager.character = character;
	}
}
