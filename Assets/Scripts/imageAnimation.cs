using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class imageAnimation : MonoBehaviour {

	// Use this for initialization
	void Start()  
	{  
		StartCoroutine(wait1());  

	}  

	IEnumerator wait1()  
	{  


		yield return new WaitForSeconds(3); 
		GetComponent<Graphic>().CrossFadeColor(Color.clear, 5, false, true);//RGBA(0,0,0,0)  
	}  

}  
