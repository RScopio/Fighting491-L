using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class CountDownTime : MonoBehaviour {
	public float RemainTime;
	public Text counter;
	public bool waittime;
	// Use this for initialization
	void Start () {
		counter = GetComponent<Text> ();

	}


	
	// Update is called once per frame
	void Update () {
		
		if (RemainTime > 99) {
			
			RemainTime -= Time.deltaTime;
			waittime = false;
		} else if (RemainTime <= 99 && RemainTime > 0) {
			waittime = true;
			RemainTime -= Time.deltaTime;
		} else {
		
			RemainTime = 0;
		}
		if (waittime==true) {
			counter.text = "" + Mathf.Round (RemainTime);
		}

	}
}
