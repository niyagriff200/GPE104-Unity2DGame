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
    public float score = 0f;
    public float topScore = 0f;
    public List<Transform> meteorSpawnPoints;

    [Header("Meteor Spawning")]
    public float meteorSpawnInterval = 2f;
    private float meteorSpawnTimer;
    private List<GameObject> activeMeteors = new List<GameObject>();

    [Header("Target Tracking")]
    public int targetsRemaining;

    [Header("Heal Pickup Spawning")]
    public GameObject healPickupPrefab;
    public float healSpawnInterval = 120f;
    public float healSpawnRadius = 5f;
    private float healSpawnTimer = 0f;
    private List<GameObject> activeHealPickups = new List<GameObject>();


    [Header("Game States")]
    public GameObject mainMenuState;
    public GameObject gameplayState;
    public GameObject gameOverState;

    [Header("Audio Clips")]
    public AudioClip shootClip;
    public AudioClip alarmClip;
    public AudioClip damageClip;
    public AudioClip destroyClip;
    public AudioClip meteorClip;
    public AudioClip backgroundMusic;
    public AudioClip healClip;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        ShowMainMenu();
        PlayBackgroundMusic();
        topScore = PlayerPrefs.GetFloat("TopScore", 0f);

    }

    private void Update()
    {
        if (gameplayState.activeInHierarchy)
        {
            StartGameplay();
        }

        if (players.Count > 0 && players[0].pawn == null)
        {
            ShowGameOver();
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
        activeMeteors.Add(newMeteor);
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

        if (score > topScore)
        {
            topScore = score;
            PlayerPrefs.SetFloat("TopScore", topScore);
            PlayerPrefs.Save();
        }
    }


    public void WinGame()
    {
        Debug.Log("You Win!");

        if (score > topScore)
        {
            topScore = score;
            Debug.Log("New top score: " + topScore);
        }
    }

    public void LoseGame()
    {
        Debug.Log("You Lose!");
        Debug.Log("Final score: " + score);
    }

    public void AddTarget()
    {
        targetsRemaining++;
    }

    public void RemoveTarget()
    {
        targetsRemaining--;
    }

    public bool IsPlayerAlive()
    {
        return players.Count > 0 &&
               players[0].pawn != null &&
               players[0].pawn.health != null &&
               players[0].pawn.health.IsAlive();
    }

    public void ShowMainMenu()
    {
        gameplayState.SetActive(false);
        gameOverState.SetActive(false);
        mainMenuState.SetActive(true);
       
    }


    public void ShowGameplay()
    {
        gameplayState.SetActive(true);
        gameOverState.SetActive(false);
        mainMenuState.SetActive(false);

        meteorSpawnTimer = 0f;
        score = 0f;
        players = new List<PlayerController>();
        activeMeteors.Clear();
        SpawnPlayerController();
        SpawnPlayer();
    }

    public void ShowGameOver()
    {
        gameplayState.SetActive(false);
        gameOverState.SetActive(true);
        mainMenuState.SetActive(false);

        foreach (GameObject meteor in activeMeteors)
        {
            if (meteor != null)
            {
                Destroy(meteor);
            }
        }

        activeMeteors.Clear();
        players.Clear();
        activeHealPickups.Clear();

    }


    public void StartGameplay()
    {
        if (IsPlayerAlive())
        {
            meteorSpawnTimer += Time.deltaTime;
            if (meteorSpawnTimer >= meteorSpawnInterval)
            {
                SpawnMeteor();
                meteorSpawnTimer = 0f;
            }

            healSpawnTimer += Time.deltaTime;
            if (healSpawnTimer >= healSpawnInterval)
            {
                SpawnHealPickup();
                healSpawnTimer = 0f;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit Game was pressed.");
    }

    public void SpawnHealPickup()
    {
        if (players.Count == 0 || players[0].pawn == null)
            return;

        Transform playerTransform = players[0].pawn.transform;
        Vector2 offset = Random.insideUnitCircle * healSpawnRadius;
        Vector3 spawnPos = playerTransform.position + new Vector3(offset.x, offset.y, 0f);

        GameObject pickup = Instantiate(healPickupPrefab, spawnPos, Quaternion.identity);
        activeHealPickups.Add(pickup);
    }


    public void PlayBackgroundMusic()
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (audio != null && backgroundMusic != null)
        {
            
            audio.clip = backgroundMusic;
            audio.loop = true;
            audio.spatialBlend = 0f;
            audio.Play();
        }
    }

}
