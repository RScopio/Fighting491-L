using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSingleton : MonoBehaviour {

    private static SimpleSingleton instance = null;

    public static SimpleSingleton Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        Debug.Log("SINGLETON UPDATE");
    }
}
