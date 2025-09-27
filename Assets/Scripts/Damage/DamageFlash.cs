using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;

    private Color originalColor;
    private float timer = 0f;
    private bool isFlashing = false;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        spriteRenderer.color = flashColor;
        timer = flashDuration;
        isFlashing = true;
    }

    private void Update()
    {
        if (isFlashing)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                spriteRenderer.color = originalColor;
                isFlashing = false;
            }
        }
    }
}
