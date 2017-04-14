using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections.Generic;
using System.IO;

public class CharacterSelectionAction : MonoBehaviour, IPointerEnterHandler, ISelectHandler
{

    //public Animator spriteAnimator;
    public CharacterPreview spritePreviewLeft;
    public CharacterPreview spritePreviewRight;

    private enum Player
    {
        Left,
        Right
    }

    private Player currentPlayer = Player.Left;


    private CharacterInfo characterInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {

    }

    public void OnSelect(BaseEventData eventData)
    {
        //characterInfo = GameObject.Find("GameController").GetComponent<CharacterInfo>();
        //int characterIndex = CharacterInfo.characters[gameObject.tag];
        //spriteAnimator.SetInteger("characterSelectState", characterIndex);
    }

    public void SetPlayerLeft()
    {
        currentPlayer = Player.Left;
    }

    public void SetPlayerRight()
    {
        currentPlayer = Player.Right;
    }

    public void SelectedCharacter()
    {
        characterInfo = GameObject.Find("GameController").GetComponent<CharacterInfo>();
        string character = gameObject.tag;
        int characterIndex = CharacterInfo.characters[gameObject.tag];
        if (currentPlayer == Player.Left)
        {
            //set selected character
            characterInfo.Character = character;

            //change preview
            spritePreviewLeft.ChangePreview(characterIndex);
        }
        else if (currentPlayer == Player.Right)
        {
            //set selected character
            characterInfo.OtherCharacter = character;

            //change preview
            spritePreviewRight.ChangePreview(characterIndex);
        }
    }
}
