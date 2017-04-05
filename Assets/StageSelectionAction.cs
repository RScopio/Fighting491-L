using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;

public class StageSelectionAction : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{

	public Animator spriteAnimator;



	public void OnPointerEnter(PointerEventData eventData)
	{

	}

	public void OnSelect(BaseEventData eventData)
	{
		
		int stageIndex = StageInfo.StagesDictionary[gameObject.tag];
		spriteAnimator.SetInteger("stageSelectState", stageIndex);
		Debug.Log ("selected stage " + gameObject.tag);

	}

	public void SelectedCharacter()
	{
		
		string stage = gameObject.tag;
		StageInfo.SelectedStage = stage;
		Debug.Log ("selected stage " + gameObject.tag);
		TransitionToFightScene ();
	}


	public void TransitionToFightScene()
	{
		GameObject.Find("GameController").GetComponent<SceneInfo>().TransitionToScene("battle");

	}
}
