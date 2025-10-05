using UnityEngine;
using UnityEngine.Audio;

public class DamageOnCollision : MonoBehaviour
{
    public float damageAmount = 1.0f;
    public bool instantKill = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject target = other.gameObject;

        if (target.GetComponent<Meteor>() != null)
        {
            GameManager.instance.AddScore(10f);
        }

        DamageFlash flash = target.GetComponent<DamageFlash>();
        if (flash != null)
        {
            flash.Flash();
        }

        CameraShake shake = Camera.main.GetComponent<CameraShake>();
        if (shake != null)
        {
            shake.Shake();
        }

        KnockbackOnDamage knockback = target.GetComponent<KnockbackOnDamage>();
        if (knockback != null)
        {
            Vector3 hitDirection = (target.transform.position - transform.position).normalized;
            knockback.ApplyKnockback(hitDirection);
        }

        Health health = target.GetComponent<Health>();
        if (health != null)
        {
            if (instantKill)
            {
                health.InstaKill();
            }
            else
            {
                health.TakeDamage(damageAmount);


                if (GameManager.instance.damageClip != null)
                {
                    AudioSource.PlayClipAtPoint(GameManager.instance.damageClip, target.transform.position, 1f);
                }

            }
        }

      
        if (GetComponent<Bullet>() != null)
        {
            Destroy(gameObject);
        }
    }
}
