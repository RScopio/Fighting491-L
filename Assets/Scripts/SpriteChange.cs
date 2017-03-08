using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{

    private string stageImageName;


    void Update()
    {
        stageImageName = StageSelect.stageindex + "";

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("Sprites/SpriteSheets/Stageselect/" + stageImageName);

        if (StageSelect.stageindex > 0 && StageSelect.stageindex < StageInfo.Stages.Count)
        {
            StageInfo.SelectedStage = StageInfo.Stages[StageSelect.stageindex];
        }
        else
        {
            StageInfo.SelectedStage = StageInfo.Stages[0];
        }
    }
}
