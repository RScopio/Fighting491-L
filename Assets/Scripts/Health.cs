using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Dictates health of an object
/// Regenative health an option
/// </summary>
public class Health : MonoBehaviour
{

    public float CurrentHealth;
    public float MaxHealth;
    public float RegenRate;
    public bool DoesRegen = false;


    void Start()
    {
        //CurrentHealth = MaxHealth;
        CurrentHealth = Random.Range(0, MaxHealth);


        if (DoesRegen)
        {
            StartCoroutine(RegenHealth());
        }

    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            transform.gameObject.SetActive(false);
        }
    }

    IEnumerator RegenHealth()
    {
        while (true)
        {
            CurrentHealth += 0.01f;
            yield return new WaitForSeconds(RegenRate);
        }
    }
}

