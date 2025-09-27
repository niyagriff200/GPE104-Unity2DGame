using UnityEngine;

public class DeathRecenter : Death
{
    protected override void Die(Vector3 position)
    {
        transform.position = position;
    }

    public override void Die()
    {
        transform.position = Vector3.zero;
    }
}
