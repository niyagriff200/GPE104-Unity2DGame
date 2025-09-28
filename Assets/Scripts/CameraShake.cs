using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeIntensity = 0.1f;
    public float shakeDuration = 0.2f;

    private Vector3 originalPosition;
    private float timer;

    private void Start()
    {
        originalPosition = transform.position;
    }

    public void Shake()
    {
        timer = shakeDuration;
    }

    private void Update()
    {
        if (timer > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeIntensity;
            timer -= Time.deltaTime;
        }
        else
        {
            transform.position = originalPosition;
        }
    }
}
