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
        if (hasDied == false)
        {
            hasDied = true;
            GameManager.instance.RemoveTarget();
            base.Die();
        }
    }
}
