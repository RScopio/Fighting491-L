using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CountDownTime : MonoBehaviour {
	public float RemainTime;
	public Text counter;
	// Use this for initialization
	void Start () {
		counter = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		RemainTime -= Time.deltaTime;
		counter.text =""+Mathf.Round(RemainTime);
	}
}
