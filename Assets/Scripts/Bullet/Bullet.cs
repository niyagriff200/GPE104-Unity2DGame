using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageOnCollision damageOnCollision;
    public MoveForward moveForward;

    public void Awake()
    {
        // Load our component variables
        damageOnCollision = GetComponent<DamageOnCollision>();
        moveForward = GetComponent<MoveForward>();
    }
}