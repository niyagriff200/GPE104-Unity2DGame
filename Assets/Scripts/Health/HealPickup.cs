using UnityEngine;

public class HealPickup : MonoBehaviour
{
    public float healAmount = 2.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPawn pawn = other.GetComponent<PlayerPawn>();
        if (pawn != null && pawn.health != null)
        {
            AudioSource.PlayClipAtPoint(GameManager.instance.healClip, transform.position, 1f);
            pawn.health.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
