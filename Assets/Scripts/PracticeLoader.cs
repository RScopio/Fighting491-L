using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeLoader : MonoBehaviour {

    CharacterInfo charInfo;

    void Start()
    {
        GameObject gameController = GameObject.Find("GameController");
        charInfo = gameController.GetComponent<CharacterInfo>();

        //Finds players selected character
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

        //load player
        player.transform.position = GameObject.Find("PlayerSpawn").transform.position;
        Instantiate(player);

    }
}
