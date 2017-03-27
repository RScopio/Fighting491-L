using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReadyButtonScript : MonoBehaviour
{

    private SceneInfo sceneInfo;

    private StageInfo stageInfo;

    void Start()
    {
        stageInfo = GameObject.Find("GameController").GetComponent<StageInfo>();
    }

    public void TransitionToStageSelect()
    {
        sceneInfo = GameObject.Find("GameController").GetComponent<SceneInfo>();
        if (stageInfo.GameMode == StageInfo.GameType.Training)
        {
            sceneInfo.TransitionToScene("practiceScene");
        }
        else
        {
            sceneInfo.TransitionToScene("Stageselect");
        }
    }

    public void TransitionToFightScene()
    {
        sceneInfo = GameObject.Find("GameController").GetComponent<SceneInfo>();
        sceneInfo.TransitionToScene("battle");
    }
}
