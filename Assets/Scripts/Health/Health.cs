using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 10.0f;
    protected float currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void Heal(float health)
    {
        currentHealth += health;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public virtual void TakeDamage(float health)
    {
        currentHealth -= health;

        if (currentHealth <= 0)
        {
            currentHealth = 0;

            Death death = GetComponent<Death>();

            if (death != null)
            {
                death.Die();
                if (GetComponent<PlayerPawn>() != null)
                {
                    Debug.Log("There is no PlayerPawn");
                }
            }
            else
            {
                Debug.LogWarning(gameObject + " doesn't have a Death Component.");
            }
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public float PercentHealth()
    {
        return currentHealth / maxHealth;
    }

    public virtual void HealToFull()
    {
        currentHealth = maxHealth;
    }

    public virtual void InstaKill()
    {
        currentHealth = 0;

        Death death = GetComponent<Death>();

        if (death != null)
        {
            death.Die();
            if (GetComponent<PlayerPawn>() != null)
            {
                Debug.Log("There is no PlayerPawn");
            }
        }
        else
        {
            Debug.LogWarning(gameObject + " doesn't have a Death Component.");
        }
    }
}
