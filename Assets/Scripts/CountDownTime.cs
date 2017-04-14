using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTime : MonoBehaviour
{
    public float RemainTime;
    public Text counter;

    void Start()
    {
        counter = GetComponent<Text>();
    }

    void Update()
    {
        if (RemainTime > 0)
        {
            RemainTime -= Time.deltaTime;
        }
        else
        {
            RemainTime = 0;
            SceneManager.LoadScene(1);
        }
        counter.text = "" + Mathf.Round(RemainTime);
    }
}
