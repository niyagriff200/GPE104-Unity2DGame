using UnityEngine;
using UnityEngine.Audio;

public class ShooterBullet : Shooter
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public override void Shoot()
    {
        if (bulletPrefab != null)
        {
            if (bulletSpawn != null)
            {
                Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

                if (GameManager.instance.shootClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(GameManager.instance.shootClip);
                }
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
