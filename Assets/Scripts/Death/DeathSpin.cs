using UnityEngine;

public class DeathSpin : Death
{
    private bool isDying = false;
    public float spinRate;
    public float scaleRate;
    public float duration;
    private float timer = 0f;

    protected override void Die(float spinRate, float scaleRate, float duration)
    {
        this.spinRate = spinRate;
        this.scaleRate = scaleRate;
        this.duration = duration;
        isDying = true;
    }

    private void Update()
    {
        if (isDying)
        {
            timer += Time.deltaTime;
            transform.Rotate(0f, 0f, spinRate * Time.deltaTime);
            transform.localScale -= Vector3.one * scaleRate * Time.deltaTime;

            if (timer >= duration || transform.localScale.x <= 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }

    public override void Die()
    {
        Die(360f, 0.5f, 1.5f);
    }
}
