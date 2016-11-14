using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{

    public float DamageValue = 10f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Health enemy = collision.transform.GetComponent<Health>();
        if (collision.transform.root != transform.root && enemy)
        {
            enemy.CurrentHealth -= DamageValue;
        }
    }
}
