using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    //key = spritesheet name
    //value = tag/name/identifier
    public static Dictionary<string, string> characters = new Dictionary<string, string>()
    {
        {"SlimeSpriteFinal"  , "slime"},
        {"HalAlpha" , "hal"}
    };

    //    {"blanka" , "fighterselect_2"},
    //    {"guile" , "fighterselect_3"},
    //    {"ken" , "fighterselect_4"},
    //    {"chunli" , "fighterselect_5"},
    //    {"zangief" , "fighterselect_6"},
    //    {"dhalsim" , "fighterselect_7"}
    //};

    private string _character;
    public string character
    {
        get { return _character; }
        set { _character = value; }
    }
}
