using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth = 10.0f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float health)
    {
        currentHealth += health;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }

    public void TakeDamage(float health)
    {
        currentHealth -= health;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death death = GetComponent<Death>();
            if (death != null) death.Die(); // Handles missing death component safely
        }
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }

    public float PercentHealth()
    {
        return (float)currentHealth / maxHealth;
    }

    public void HealToFull()
    {
        currentHealth = maxHealth;
    }

    public void InstaKill()
    {
        currentHealth = 0;
        Death death = GetComponent<Death>();
        if (death != null) death.Die(); // Handles missing death component safely
    }
}
