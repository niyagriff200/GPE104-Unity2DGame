using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Color flashColor = Color.red;
    public Color normalColor = Color.white;
    public float flashDuration = 0.5f;

    private bool isFlashing = false;
    private float flashTimer = 0f;
    private bool flashActive = false;

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.color = normalColor;
        }
    }

    private void Update()
    {
        if (isFlashing)
        {
            flashTimer -= Time.deltaTime;
            Debug.Log("Flash timer: " + flashTimer);

            if (flashTimer <= 0f)
            {
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = normalColor;
                }

                isFlashing = false;
                flashActive = false;
                Debug.Log("Flash ended.");
            }
        }
    }

    public void Flash()
    {
        if (flashActive) return;
        flashActive = true;

        if (spriteRenderer != null)
        {
            isFlashing = true;
            flashTimer = flashDuration;
            spriteRenderer.color = flashColor;
            Debug.Log("Flash triggered. Timer set to: " + flashTimer);
        }
    }
}
