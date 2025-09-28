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

    protected override void Start()
    {
        base.Start();
    }

    public override void Move(Vector3 moveVector)
    {
        transform.position += (moveVector * moveSpeed) * Time.deltaTime;
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
        transform.position += (moveVector * turboSpeed) * Time.deltaTime;
    }

    public override void TeleportRandom()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        transform.position = new Vector3(x, y, 0);
    }
}
