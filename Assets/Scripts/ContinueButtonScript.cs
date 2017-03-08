using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class ContinueButtonScript : MonoBehaviour
{
    private StageInfo stageInfo;

    void Start()
    {
        stageInfo = GameObject.Find("GameController").GetComponent<StageInfo>();
    }

    public void TransitionToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void SetGameModeAI()
    {
        stageInfo.GameMode = StageInfo.GameType.AI;
    }

    public void SetGameModeTraining()
    {
        stageInfo.GameMode = StageInfo.GameType.Training;
    }

    public void SetGameModeLocal()
    {
        stageInfo.GameMode = StageInfo.GameType.Local;
    }

    public void SetGameModeMultiplayer()
    {
        stageInfo.GameMode = StageInfo.GameType.Multiplayer;
    }
}


