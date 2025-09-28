using UnityEngine;

public class MeteorTargetPlayer : MonoBehaviour
{
    public float moveSpeed = 3f;
    private Vector3 moveDirection;

    void Start()
    {
        GameObject player = GameManager.instance.players[0].pawn.gameObject;
        moveDirection = (player.transform.position - transform.position).normalized;
        transform.up = moveDirection;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
