using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Damage : MonoBehaviour
{

    public float DamageValue = 10f;

    public void OnCollisionEnter2D(Collision2D collision)
    {

        Health enemy = collision.transform.GetComponent<Health>();
        if (collision.transform.root != transform.root && enemy)
        {
            DefaultController enemyController = enemy.GetComponent<DefaultController>();
            if (enemyController && !enemyController.Nullify)
            {
                enemy.CurrentHealth -= DamageValue;
                enemyController.Damaged = true;
            }
						ComputerAI aiController = enemy.GetComponent<ComputerAI>();
						if (aiController && !aiController.Nullify)
						{
              enemy.CurrentHealth -= DamageValue;
              aiController.Damaged = true;
						}
        }
    }
}
