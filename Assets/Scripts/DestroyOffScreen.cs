using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public float buffer = 1f;

    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < -buffer || pos.x > 1 + buffer || pos.y < -buffer || pos.y > 1 + buffer)
        {
            Destroy(gameObject);
        }
    }
}
