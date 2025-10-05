using UnityEngine;

public class Meteor : MonoBehaviour
{
    private AudioSource humSource;

    private void Start()
    {
        humSource = GetComponent<AudioSource>();
        humSource.clip = GameManager.instance.meteorClip;
        humSource.loop = true;
        humSource.spatialBlend = 1f;
        humSource.dopplerLevel = 1f;
        humSource.Play();
    }


}
