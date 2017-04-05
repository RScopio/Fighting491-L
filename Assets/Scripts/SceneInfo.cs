using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{

    public static Dictionary<string, int> scenes = new Dictionary<string, int>(){

        {"titleScreen",0}, {"mainMenu",1},{"characterSelectScene",2},{"optionsMenu",3},
        {"information",4},{"battle",5},
         {"Stageselect",6}, {"multiplayerSelect", 7}, {"practiceScene", 8}
    };

    public void TransitionToScene(string sceneName)
    {


        foreach (KeyValuePair<string, int> name in scenes)
        {

            if (sceneName == name.Key)
                SceneManager.LoadScene(name.Value);

        }


    }
}
