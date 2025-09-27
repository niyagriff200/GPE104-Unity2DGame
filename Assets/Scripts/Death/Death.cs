using UnityEngine;

public abstract class Death : MonoBehaviour
{
    public abstract void Die();

    protected virtual void Die(float spinRate, float scaleRate, float duration)
    {
        Die();
    }

    protected virtual void Die(Vector3 position)
    {
        Die();
    }
}
