using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageInfo : MonoBehaviour
{

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

    // Use this for initialization
    void Start()
    {
        GameMode = GameType.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
