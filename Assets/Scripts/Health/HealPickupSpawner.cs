using UnityEngine;

public class HealPickupSpawner : MonoBehaviour
{
    public GameObject healPickup;
    public float spawnRadius = 5f;
    public float spawnInterval = 120f; // 2 minutes

    private float timer = 0f;


    private void Update()
    {
        Debug.Log("HealPickupSpawner Update running...");

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Debug.Log("Timer reached spawn interval, spawning!");
            SpawnHealNearPlayer();
            timer = 0f;
        }
    }


    private void SpawnHealNearPlayer()
    {
        if (GameManager.instance == null || GameManager.instance.players.Count == 0)
        {
            Debug.Log("No player found — skipping heal spawn.");
            return;
        }

        Transform playerTransform = GameManager.instance.players[0].pawn.transform;
        Debug.Log("Spawning HealPickup near: " + playerTransform.name);

        Vector2 offset = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPosition = playerTransform.position + new Vector3(offset.x, offset.y, 0f);

        Instantiate(healPickup, spawnPosition, Quaternion.identity);
    }

}
