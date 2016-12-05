using UnityEngine;
using System.Collections;

/// <summary>
/// Ryan Scopio
/// Dictates health of an object
/// Regenative health an option
/// </summary>
public class Health : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject DeathAnimation;
    public float CurrentHealth;
    public float MaxHealth;
    public float RegenRateTime;
    public bool DoesRegen = false;
    private bool isRegenHealth = false;


    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void Update()
    {
        if (CurrentHealth <= 0)
        {
            //make explosions or something
            Instantiate(GameOver);
            Instantiate(DeathAnimation, transform.position, transform.rotation, null);
            transform.gameObject.SetActive(false);
        }

        if (CurrentHealth != MaxHealth && DoesRegen)
        {
            StartCoroutine(RegenHealth());
        }

    }

    IEnumerator RegenHealth()
    {
        DoesRegen = false;
        while (CurrentHealth < MaxHealth)
        {
            CurrentHealth += 1f;
            yield return new WaitForSeconds(RegenRateTime);
        }
        DoesRegen = true;
    }
}

