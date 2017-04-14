using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{

    CharacterInfo charInfo;
    StageInfo stageInfo;
    SceneInfo sceneInfo;

    public HealthBarController leftHealth;
    public HealthBarController rightHealth;

    public PlayerZoomCamera cam;

    string[] AI = { "HALAI", "SlimeAI" };

    void Start()
    {
        GameObject gameController = GameObject.Find("GameController");
        charInfo = gameController.GetComponent<CharacterInfo>();
        stageInfo = gameController.GetComponent<StageInfo>();
        sceneInfo = gameController.GetComponent<SceneInfo>();

        //this is sloppy but it's late and i'm tired
        GameObject player = Resources.Load("Prefabs/Characters/HAL") as GameObject;
        GameObject secondPlayer = Resources.Load("Prefabs/Characters/Slime") as GameObject;
        Object[] prefabs = Resources.LoadAll("Prefabs/Characters");
        foreach (Object prefab in prefabs)
        {
            if ((prefab as GameObject).name == charInfo.Character)
            {
                player = prefab as GameObject;
            }

            if (stageInfo.GameMode == StageInfo.GameType.Local && (prefab as GameObject).name == charInfo.OtherCharacter)
            {
                secondPlayer = prefab as GameObject;
            }
        }
        //load stage
        Component[] stages = GameObject.Find("Stages").GetComponentsInChildren(typeof(Transform), true);
        foreach (Component stageTransform in stages)
        {
            if (stageTransform.gameObject.name == StageInfo.SelectedStage)
            {
                stageTransform.gameObject.SetActive(true);
                break;
            }
        }

        //load left player
        player.transform.position = GameObject.Find("SpawnPointLeft").transform.position;
        GameObject playa = Instantiate(player);
        leftHealth.CharacterHealth = playa.GetComponent<Health>();
        playa.GetComponent<InputController>().JoyNum = "1";

        //load right player
        if (stageInfo.GameMode == StageInfo.GameType.Local)
        {
            secondPlayer.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            GameObject playa2 = Instantiate(secondPlayer);
            rightHealth.CharacterHealth = playa2.GetComponent<Health>();
            playa2.GetComponent<InputController>().JoyNum = "2";
        }

        //load AI
        if (stageInfo.GameMode == StageInfo.GameType.AI)
        {
            GameObject ai = Resources.Load("Prefabs/Characters/" + AI.RandomItem()) as GameObject;
            ai.transform.position = GameObject.Find("SpawnPointRight").transform.position;
            rightHealth.CharacterHealth = Instantiate(ai).GetComponent<Health>();
        }


        cam.Initialize();
    }
}

public static class ArrayExtensions
{
    // This is an extension method. RandomItem() will now exist on all arrays.
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}