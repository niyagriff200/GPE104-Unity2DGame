using UnityEngine;

public class DeathDestroy : Death
{
    public override void Die()
    {
        AudioSource.PlayClipAtPoint(GameManager.instance.destroyClip, transform.position, 1f);
        Destroy(gameObject);
    }
}
