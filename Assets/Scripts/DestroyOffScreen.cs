using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    public float buffer = 1f;

    private void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < -buffer || pos.x > 1 + buffer || pos.y < -buffer || pos.y > 1 + buffer)
        {
            Death deathComponent = GetComponent<Death>();

            if (deathComponent != null)
            {
                deathComponent.Die();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
