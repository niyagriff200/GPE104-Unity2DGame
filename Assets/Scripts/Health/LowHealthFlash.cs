using UnityEngine;

public class LowHealthFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public Color normalColor = Color.white;
    public Health health;

    public float flashInterval = 0.2f;
    private float flashTimer = 0f;
    private bool isFlashing = false;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (health == null)
        {
            health = GetComponent<Health>();
        }

        spriteRenderer.color = normalColor;
    }

    private void Update()
    {
        if (health != null && spriteRenderer != null)
        {
            if (health.PercentHealth() <= 0.25f)
            {
                flashTimer -= Time.deltaTime;

                if (flashTimer <= 0f)
                {
                    isFlashing = !isFlashing;
                    if (isFlashing)
                    {
                        spriteRenderer.color = flashColor;
                    }
                    else
                    {
                        spriteRenderer.color = normalColor;
                    }
                    flashTimer = flashInterval;
                }
            }
            else
            {
                spriteRenderer.color = normalColor;
                isFlashing = false;
                flashTimer = 0f;
            }
        }
    }
}
