using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;

public class CharacterSelectionAction : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{
    public int characterIndex;
    public Animator spriteAnimator;

    private CharacterInfo characterInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {

        spriteAnimator.SetInteger("characterSelectState", characterIndex);

    }

    public void SelectedCharacter()
    {
        characterInfo = GameObject.Find("GameController").GetComponent<CharacterInfo>();
        string character = gameObject.GetComponent<Image>().sprite.name;
        characterInfo.Character = character;
    }
}
