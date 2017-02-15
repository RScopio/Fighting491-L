using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{

    public static Dictionary<string, string> characters = new Dictionary<string, string>()
    {
        {"SlimeSpriteFinal"  , "fighterselect_0"},
        {"HalAlpha" , "fighterselect_1"},
        {"blanka" , "fighterselect_2"},
        {"guile" , "fighterselect_3"},
        {"ken" , "fighterselect_4"},
        {"chunli" , "fighterselect_5"},
        {"zangief" , "fighterselect_6"},
        {"dhalsim" , "fighterselect_7"}
    };

    private string _character;
    public string character
    {
        get { return _character; }
        set { _character = value; }
    }
}
