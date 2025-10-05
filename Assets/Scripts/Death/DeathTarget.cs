using UnityEngine;

public class DeathTarget : DeathDestroy
{
    private bool hasDied = false;

    private void Start()
    {
        GameManager.instance.AddTarget();
    }

    public override void Die()
    {
        if (!hasDied)
        {
            hasDied = true;

            if (GameManager.instance.destroyClip != null)
            {
                AudioSource.PlayClipAtPoint(GameManager.instance.destroyClip, transform.position, 1f);
            }

            GameManager.instance.RemoveTarget();
            base.Die();
        }
    }

}
