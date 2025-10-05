using Unity.VisualScripting;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Death otherObjectDeathComponent = other.gameObject.GetComponent<Death>();
        if (otherObjectDeathComponent != null)
        {
            otherObjectDeathComponent.Die();
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
