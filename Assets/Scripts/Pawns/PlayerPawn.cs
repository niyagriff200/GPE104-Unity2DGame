using UnityEngine;

public class PlayerPawn : Pawn
{
    public float moveSpeed;
    public float turboSpeed;
    public float rotateSpeed;
    public float teleportDistance;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    [SerializeField] private AudioSource alarmSource;
    private bool alarmActive = false;

    protected override void Start()
    {
        base.Start();

        // Make sure the alarmSource is ready
        if (alarmSource == null)
            alarmSource = GetComponent<AudioSource>();

        alarmSource.loop = true;
        alarmSource.spatialBlend = 0f;
        alarmSource.volume = 1f;
    }

    private void Update()
    {
        float healthPercent = health.PercentHealth();

        // Trigger alarm when health drops below 25% and alarm isn’t already playing
        if (healthPercent <= 0.25f && health.IsAlive() && !alarmActive)
        {
            if (GameManager.instance.alarmClip == null)
            {
                Debug.LogError("ALARM CLIP IS NULL!");
                return;
            }

            alarmSource.clip = GameManager.instance.alarmClip;
            alarmSource.Play();
            alarmActive = true;
        }
        // Stop alarm when health goes back above 25% or player dies
        else if ((healthPercent > 0.25f || !health.IsAlive()) && alarmActive)
        {
            alarmSource.Stop();
            alarmActive = false;
        }
    }

    public override void Move(Vector3 moveVector)
    {
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    public override void Rotate(float angle)
    {
        transform.Rotate(new Vector3(0, 0, angle * rotateSpeed) * Time.deltaTime);
    }

    public override void Teleport(Vector3 direction)
    {
        transform.position += direction.normalized * teleportDistance;
    }

    public override void MoveTurbo(Vector3 moveVector)
    {
        transform.position += moveVector * turboSpeed * Time.deltaTime;
    }

    public override void TeleportRandom()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        transform.position = new Vector3(x, y, 0);
    }
}
