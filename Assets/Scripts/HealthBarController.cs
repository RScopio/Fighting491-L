using UnityEngine;
using System.Collections;

//This script is lazy coding
public class HealthBarController : MonoBehaviour
{
    [HideInInspector]
    public Health CharacterHealth;
    public RectTransform HealthImage;
    float defaultScale;

    void Start()
    {
        defaultScale = HealthImage.localScale.x;
        HealthImage.localScale = new Vector3(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (CharacterHealth)
        {
            HealthImage.localScale = new Vector2(Mathf.Lerp(0, defaultScale, CharacterHealth.CurrentHealth / CharacterHealth.MaxHealth), HealthImage.localScale.y);
        }
    }
}
