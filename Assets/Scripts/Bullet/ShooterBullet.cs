using UnityEngine;

public class ShooterBullet : Shooter
{
    public override void Shoot()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("ShooterBullet is missing bulletPrefab or bulletSpawnPoint.");
        }
    }
}
