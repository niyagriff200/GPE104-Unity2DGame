using UnityEngine;

public class MeteorTargetPlayer : MonoBehaviour
{
    public float moveSpeed = 1f;
    private Vector3 moveDirection;

    private void Start()
    {
        GameObject player = GameManager.instance.players[0].pawn.gameObject;
        moveDirection = (player.transform.position - transform.position).normalized;
        transform.up = moveDirection;
    }

    private void Update()
    {
        if (GameManager.instance.players[0] != null)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
