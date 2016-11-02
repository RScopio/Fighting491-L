using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{

    public AudioClip AttackSound;
    //public AudioClip kickSound;
    public AudioClip JumpSound;

    public void Attack()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySingle(AttackSound);
        }
    }

    public void Power()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySingle(AttackSound);
        }
    }

    public void Jump()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.PlaySingle(JumpSound);
        }
    }
}
