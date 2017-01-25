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
	public GameObject characterBackgroundPortait;
	public GameObject characterSelectionSprite;
	public void start(){
		
	}
	public void update(){
		
	}

	public void OnPointerEnter(PointerEventData eventData){


			

	}

	public void OnSelect(BaseEventData eventData){
		

		foreach (KeyValuePair<string,string> name in GameManager.characters) {
			
			if (gameObject.GetComponent<Image>().sprite.name == name.Value) {

				Sprite tempSprite = Resources.Load<Sprite> ("Textures/streetfighterlargePortraits/" + name.Key);
				characterBackgroundPortait.GetComponent<Image>().sprite = tempSprite;

				var tempSpriteArray = Resources.LoadAll<Sprite> ("Textures/Sprites/Sprite Sheets/SlimeSpriteFinal_48" );

				//characterSelectionSprite.GetComponent<Image> ().sprite = tempSpriteArray[System.Array.IndexOf(tempSpriteArray, "idle_0")];


				Debug.Log (tempSpriteArray.Length);

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
