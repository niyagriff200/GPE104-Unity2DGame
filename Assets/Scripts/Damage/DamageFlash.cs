using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public Color normalColor = Color.white;
    public float flashDuration = 0.5f;

    private bool isFlashing = false;
    private float flashTimer = 0f;

    private void Start()
    {
        // Try to find the sprite renderer if not assigned
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        // Set the default color
        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }
    }

    private void Update()
    {
        // If flashing is active, count down the timer
        if (isFlashing == true)
        {
            flashTimer -= Time.deltaTime;

            if (flashTimer <= 0f)
            {
                // Reset color and stop flashing
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = normalColor;
                }

                isFlashing = false;
            }
        }
    }

    public void Flash()
    {
        // Start the flash effect
        if (spriteRenderer != null)
        {
            spriteRenderer.color = flashColor;
            flashTimer = flashDuration;
            isFlashing = true;
        }
    }
}
