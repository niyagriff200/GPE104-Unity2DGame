using UnityEngine;

public class DeathTarget : DeathDestroy
{
    void Start()
    {
        GameManager.instance.AddTarget();
    }

    private bool hasDied = false;

    public override void Die()
    {
        if (hasDied) return;
        hasDied = true;

        GameManager.instance.AddScore(10f);
        GameManager.instance.RemoveTarget();
        base.Die();
    }

}
