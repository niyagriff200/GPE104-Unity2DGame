using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5f;

    private void Update()
    {
        transform.position += transform.up * moveSpeed * Time.deltaTime;
    }
}
