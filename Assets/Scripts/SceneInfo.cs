using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInfo : MonoBehaviour
{

    public static Dictionary<string, int> scenes = new Dictionary<string, int>(){

        {"mainMenu",1},{"characterSelectScene",2},{"optionsMenu",3},
        {"battle",5},{"titleScreen",0},{"information",4},
         {"Stageselect",6}
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
