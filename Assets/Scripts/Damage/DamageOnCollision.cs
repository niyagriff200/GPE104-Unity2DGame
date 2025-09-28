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

        Death death = GetComponent<Death>();
        if (death != null)
        {
            death.Die();
        }
    }
}
