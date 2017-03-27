using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{

    public static List<string> Stages = new List<string>()
    {
        "Lake", "Villa", "Waterfall", "River", "Town", "Station"
    };

    public static string SelectedStage = "Lake";

    public enum GameType
    {
        None,
        AI,
        Training,
        Local,
        Multiplayer
    }

    [HideInInspector]
    public GameType GameMode;

    void Start()
    {
        GameMode = GameType.None;
    }
}
