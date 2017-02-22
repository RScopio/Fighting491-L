using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;

public class CharacterSelectionAction : MonoBehaviour,IPointerEnterHandler, ISelectHandler{
	public string character;
	private CharacterInfo characterInfo;
	public EventSystem eventsystem;
	public GameObject characterBackgroundPortait;
	public GameObject characterSelectionSprite;
	public Animator spriteAnimator;



	public void start(){


		
	}
	public void update(){
		
	}

	public void OnPointerEnter(PointerEventData eventData){


			

	}

	public void OnSelect(BaseEventData eventData){
		

		foreach (KeyValuePair<string,string> name in CharacterInfo.characters) {
			
			if (gameObject.GetComponent<Image>().sprite.name == name.Value) {

				Sprite tempSprite = Resources.Load<Sprite> ("Textures/streetfighterlargePortraits/" + name.Key);
				characterBackgroundPortait.GetComponent<Image>().sprite = tempSprite;

				var spriteStateNumber = int.Parse ((name.Value[name.Value.Length - 1]).ToString ());//converts from char to string to int because Parse can only take strings
				spriteAnimator.SetInteger ("characterSelectState", spriteStateNumber );




				break;
			}
		}

	}

	public void SelectedCharacter(){


        characterInfo = GameObject.Find("GameController").GetComponent<CharacterInfo>();
		character = gameObject.GetComponent<Image> ().sprite.name;
		var colors = this.GetComponent<Button> ().colors;
		colors.normalColor = Color.gray;
		colors.highlightedColor = Color.gray;
		GetComponent<Button> ().colors = colors;

        characterInfo.character = character;
	}
}
