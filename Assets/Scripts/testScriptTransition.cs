using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class testScriptTransition : MonoBehaviour {
	GameManager gameManager;
	// Use this for initialization
	void Start () {
		Debug.Log (GameObject.Find ("GameManager").GetComponent<GameManager> ().character);
		gameManager = GameObject.Find ("GameManager").GetComponent<GameManager>();
		int i = 0;
		foreach(KeyValuePair<string,string> name in GameManager.characters){
			
			if (gameManager.character == name.Value) {
				
				Sprite[] temp = Resources.LoadAll<Sprite> ("Textures/fighterselect");
				gameObject.GetComponent<Image> ().sprite = temp[i];;
			}
			i++;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
