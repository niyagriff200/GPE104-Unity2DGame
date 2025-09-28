using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public abstract void Shoot();
}
