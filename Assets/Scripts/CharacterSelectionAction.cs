using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterSelectionAction : MonoBehaviour {
	public string character;
	private GameManager gameManager;
	public void start(){
		
	}

	public void SelectedCharacter(){
		Debug.Log ("heyyyyyyyy" + GameObject.Find ("GameManager").GetComponent<GameManager> ());

		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		character = gameObject.GetComponent<Image> ().sprite.name;
		var colors = this.GetComponent<Button> ().colors;
		colors.normalColor = Color.gray;
		colors.highlightedColor = Color.gray;
		GetComponent<Button> ().colors = colors;
		Debug.Log ("CharacterSelected");
		gameManager.character = character;
	}
}
