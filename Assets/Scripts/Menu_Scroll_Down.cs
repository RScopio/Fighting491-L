using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Menu_Scroll_Down : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform GameObject;
    public bool Open;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Open = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Open = false;
    }

    // Use this for initialization
    void Start () {
        GameObject = transform.FindChild("GameObject").GetComponent<RectTransform>(); 
	}
	
	// Update is called once per frame
	void Update () {
       
            Vector3 scale = GameObject.localScale;
            scale.y = Mathf.Lerp(scale.y, Open ? 1:0, Time.deltaTime * 12);
            GameObject.localScale = scale;
        
	}
}
