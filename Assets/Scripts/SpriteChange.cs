using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {
    public string a;
    public string b;
    public float x;
    public float y;
    public float z;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        b = StageSelect.stageindex+"";

        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = Resources.Load<Sprite>("Sprites/SpriteSheets/Stageselect/" + b);
        
    }
}
