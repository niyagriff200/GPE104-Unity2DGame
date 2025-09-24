using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private float damageAmount = 1.0f;
    private bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (instantKill)
            {
                health.InstaKill();
            }
            else
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
