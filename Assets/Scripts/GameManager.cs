using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    private static GameManager _sharedInstance = null;

    public static GameManager sharedInstance { get { return _sharedInstance; } }


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

    public static Dictionary<string, int> scenes = new Dictionary<string, int>(){

        {"mainMenu",1},{"characterSelectScene",2},{"optionsMenu",3},
        {"battle",5},{"titleScreen",0},{"information",4}

    };



    private string _character;
    public string character
    {
        get { return _character; }
        set { _character = value; }
    }



    // Use this for initialization
    private void Awake()
    {

        //		if (this != null && sharedInstance != this) {
        //				Destroy (this.gameObject);
        //		} else {
        //			_sharedInstance = this;
        //		}

        DontDestroyOnLoad(transform.gameObject);
        _sharedInstance = this;



    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TransitionToScene(string sceneName)
    {


        foreach (KeyValuePair<string, int> name in scenes)
        {

            if (sceneName == name.Key)
                SceneManager.LoadScene(name.Value);

        }


    }

}//end of class
