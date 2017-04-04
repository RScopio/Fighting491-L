using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Damage : MonoBehaviour
{

    public float DamageValue = 10f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
		
        Health enemy = collision.transform.GetComponent<Health>();
        if (collision.transform.root != transform.root && enemy)
        {
            DefaultController enemyController = enemy.GetComponent<DefaultController>();
            if (!enemyController.Nullify)
            {
				//Debug.Log ("damaged");
				//enemy.CurrentHealth -= DamageValue;
				enemy.takeDamage(DamageValue);
                enemyController.Damaged = true;
            }
        }
    }
}
