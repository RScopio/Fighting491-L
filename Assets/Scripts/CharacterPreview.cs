using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPreview : MonoBehaviour
{

    public Sprite[] Previews = new Sprite[4];

    public void ChangePreview(int index)
    {
        GetComponent<Image>().sprite = Previews[index];
    }
}
