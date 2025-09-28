using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Players")]
    public List<PlayerController> players;

    [Header("Prefabs")]
    public GameObject playerPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject meteorPrefab;

    [Header("Game Data")]
    public float score;
    public float topScore;
    public List<Transform> meteorSpawnPoints;

    [Header("Meteor Spawning")]
    public float meteorSpawnInterval = 2f;
    public int meteorCount = 10;
    private int meteorsSpawned = 0;
    private float meteorSpawnTimer;

    [Header("Target Tracking")]
    public int targetsRemaining;

    private void Awake()
    {
        if (instance != null) Destroy(gameObject);
        else instance = this;
    }

    private void Start()
    {
        players = new List<PlayerController>();
        SpawnPlayerController();
        SpawnPlayer();
    }

    private void Update()
    {
        if (meteorsSpawned < meteorCount)
        {
            meteorSpawnTimer += Time.deltaTime;
            if (meteorSpawnTimer >= meteorSpawnInterval)
            {
                SpawnMeteor();
                meteorSpawnTimer = 0f;
                meteorsSpawned++;
            }
        }
    }

    public Vector3 GetRandomSpawnPoint()
    {
        return meteorSpawnPoints[Random.Range(0, meteorSpawnPoints.Count)].position;
    }

    public void SpawnMeteor()
    {
        GameObject newMeteor = Instantiate(meteorPrefab, GetRandomSpawnPoint(), Quaternion.identity);
        newMeteor.transform.Rotate(0f, 0f, Random.Range(0f, 360f));
    }

    public void SpawnPlayerController()
    {
        GameObject controllerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity);
        PlayerController controller = controllerObj.GetComponent<PlayerController>();
        players.Add(controller);
    }

    public void SpawnPlayer()
    {
        if (players[0].pawn != null && players[0].pawn.gameObject.scene.IsValid())
        {
            Destroy(players[0].pawn.gameObject);
        }

        GameObject pawnObj = Instantiate(playerPawnPrefab, Vector3.zero, Quaternion.identity);
        Pawn pawn = pawnObj.GetComponent<Pawn>();

        if (pawn != null)
        {
            players[0].pawn = pawn;
            players[0].GetComponent<PlayerController>().pawn = pawn;
        }
    }

    public void AddScore(float amount)
    {
        score += amount;
        Debug.Log("Score added. Current score: " + score);
    }

    public void WinGame()
    {
        if (score > topScore)
        {
            Debug.Log("You Win!");
            topScore = score;
        }
        else
        {
            Debug.Log("You Lose!");
        }
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
    }

    public void AddTarget()
    {
        targetsRemaining++;
        Debug.Log("Target added. Total: " + targetsRemaining);
    }

    public void RemoveTarget()
    {
        targetsRemaining--;
        Debug.Log("Target removed. Remaining: " + targetsRemaining);

        if (targetsRemaining <= 0)
        {
            if (IsPlayerAlive())
            {
                WinGame();
            }
            else
            {
                LoseGame();
            }
        }
    }

    public bool IsPlayerAlive()
    {
        return players.Count > 0 &&
               players[0].pawn != null &&
               players[0].pawn.health != null &&
               players[0].pawn.health.IsAlive();
    }

}
