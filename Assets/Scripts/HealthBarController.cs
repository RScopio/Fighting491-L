using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

//This script is lazy coding
public class HealthBarController : MonoBehaviour {

    Health health;
	//[SyncVar]
    public GameObject FrontHealth;
    float defaultScale;

	// Use this for initialization
	void Start () {
        health = transform.root.GetComponent<Health>();
        defaultScale = FrontHealth.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        if(health)
        {
            FrontHealth.transform.localScale = new Vector3(Mathf.Lerp(0, defaultScale, health.CurrentHealth / health.MaxHealth), FrontHealth.transform.localScale.y, FrontHealth.transform.localScale.z);
        }
	}
}
