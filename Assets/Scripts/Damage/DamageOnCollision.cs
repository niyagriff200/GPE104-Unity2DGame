using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 1.0f;
    public bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Meteor>() != null)
        {
            GameManager.instance.AddScore(10f);
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

        KnockbackOnDamage knockback = other.gameObject.GetComponent<KnockbackOnDamage>();
        if (knockback != null)
        {
            Vector3 hitDirection = (other.transform.position - transform.position).normalized;
            knockback.ApplyKnockback(hitDirection);
        }

        Health health = other.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (instantKill == true)
            {
                health.InstaKill();
            }
            else
            {
                health.TakeDamage(damageAmount);
            }
        }

        if (GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
        }

        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }
}
