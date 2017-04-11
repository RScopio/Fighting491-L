using UnityEngine;
using System.Collections;
using UnityEngine.UI;
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
        }
        counter.text = "" + Mathf.Round(RemainTime);
    }
}
