using UnityEngine;

public class ShooterBullet : Shooter
{
    public override void Shoot()
    {
        if (bulletPrefab != null)
        {
            if (bulletSpawn!= null)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            }
            else
            {
                Debug.LogWarning("ShooterBullet is missing bulletSpawn.");
            }
        }
        else
        {
            Debug.LogWarning("ShooterBullet is missing bulletPrefab.");
        }
    }
}
