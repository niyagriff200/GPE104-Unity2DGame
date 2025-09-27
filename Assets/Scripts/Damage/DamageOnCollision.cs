using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 1.0f;
    public bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Health health = other.gameObject.GetComponent<Health>();
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

            KnockbackOnDamage knockback = other.gameObject.GetComponent<KnockbackOnDamage>();
            if (knockback != null)
            {
                Vector3 hitDirection = other.transform.position - transform.position;
                knockback.ApplyKnockback(hitDirection);
            }

            DamageFlash flash = other.gameObject.GetComponent<DamageFlash>();
            if (flash != null)
            {
                flash.Flash();
            }

            CameraShake shake = Camera.main.GetComponent<CameraShake>();
            if (shake != null)
            {
                shake.Shake();
            }


        }
        else
        {
            Debug.LogWarning(other.gameObject + " doesn't have Health Component.");
        }
    }
}
