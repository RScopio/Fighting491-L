using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class AnimationAutoDestory : MonoBehaviour
{
    public float delay = 0f;

    void Start()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
