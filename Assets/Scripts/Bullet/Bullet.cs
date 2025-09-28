using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageOnCollision damageOnCollision;
    public MoveForward moveForward;

    private void Awake()
    {
        damageOnCollision = GetComponent<DamageOnCollision>();
        moveForward = GetComponent<MoveForward>();
    }
}
