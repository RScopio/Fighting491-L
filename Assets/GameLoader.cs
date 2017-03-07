using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    CharacterInfo charInfo;
    StageInfo stageInfo;
    SceneInfo sceneInfo;

    void Start()
    {
        GameObject gameController = GameObject.Find("GameController");
        charInfo = gameController.GetComponent<CharacterInfo>();
        stageInfo = gameController.GetComponent<StageInfo>();
        sceneInfo = gameController.GetComponent<SceneInfo>();

        //this is sloppy but it's late and i'm tired
        GameObject player = Resources.Load("Prefabs/Characters/HAL") as GameObject;
        Object[] prefabs = Resources.LoadAll("Prefabs/Characters");
        foreach (Object prefab in prefabs)
        {
            if ((prefab as GameObject).tag == charInfo.Character)
            {
                player = prefab as GameObject;
                break;
            }
        }

        player.transform.position = GameObject.Find("SpawnPointLeft").transform.position;
        Instantiate(player);

        //load other player

        //load AI

        //load practice dummy

        //load level

    }
}
