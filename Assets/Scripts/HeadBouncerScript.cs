using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBouncerScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DefaultController player = collision.gameObject.GetComponent<DefaultController>();
            if (player) player.Jump();
        }

        if (collision.gameObject.tag == "AI")
        {
            ComputerAI ai = collision.gameObject.GetComponent<ComputerAI>();
            if (ai) ai.Jump();
        }
    }


}
