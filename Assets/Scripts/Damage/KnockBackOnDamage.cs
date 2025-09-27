using UnityEngine;

public class KnockbackOnDamage : MonoBehaviour
{
    public float knockbackForce = 2f;

    public void ApplyKnockback(Vector3 hitDirection)
    {
        Vector3 direction = hitDirection;
        transform.position += direction * knockbackForce;
    }
}
