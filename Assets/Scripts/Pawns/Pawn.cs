using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector] public Health health;
    [HideInInspector] public Shooter shooter;

   
    public abstract void Move(Vector3 moveVector);
    public abstract void Rotate(float angle);
    public abstract void Teleport(Vector3 direction);
    public abstract void MoveTurbo(Vector3 moveVector);
    public abstract void TeleportRandom();

    protected virtual void Start()
    {
        
        health = GetComponent<Health>();
        shooter = GetComponent<Shooter>();
    }
}
