using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    //possibly don't need dictionary
    //key = tag
    //value = prefab name
    public static Dictionary<string, int> characters = new Dictionary<string, int>()
    {
        {"Slime"  , 0},
        {"HAL" , 1},
		{"Mal" , 2},
    };

    //    {"blanka" , "fighterselect_2"},
    //    {"guile" , "fighterselect_3"},
    //    {"ken" , "fighterselect_4"},
    //    {"chunli" , "fighterselect_5"},
    //    {"zangief" , "fighterselect_6"},
    //    {"dhalsim" , "fighterselect_7"}
    //};

    private string _character;
    public string Character
    {
        get { return _character; }
        set { _character = value; }
    }

    private string _otherCharacter;
    public string OtherCharacter
    {
        get { return _otherCharacter; }
        set { _otherCharacter = value; }
    }
}
