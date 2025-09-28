using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public abstract void Shoot();
}
