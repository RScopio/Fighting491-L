using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{

    public static List<string> Stages = new List<string>()
    {
        "Lake", "Villa", "Waterfall", "River", "Town", "Station"
    };

	//key = tag
	//value = prefab name
	public static Dictionary<string, int> StagesDictionary = new Dictionary<string, int>()
	{
		{"Lake"  , 0},
		{"Villa" , 1},
		{"Waterfall" , 2},
		{"River" , 3},
		{"Town" , 4},
		{"Station" , 5}
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
