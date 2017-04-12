using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{
    DefaultController controller;
    void Start()
    {
        controller = transform.root.GetComponent<DefaultController>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Transform enemy = collision.transform.root;
        if (collision.transform.root != transform.root && enemy && (enemy.tag == "Player" || enemy.tag == "AI"))
        {
            controller.Nullify = true;
        }
    }
}
