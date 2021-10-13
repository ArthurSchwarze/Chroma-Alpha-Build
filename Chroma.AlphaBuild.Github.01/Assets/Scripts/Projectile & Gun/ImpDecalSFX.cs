using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpDecalSFX : MonoBehaviour
{
    private AudioSource impactSource;
    public AudioClip[] impactSFXs;
    private AudioClip impactClip;

    private void Awake()
    {
        impactSource = this.GetComponent<AudioSource>();
        playImpactSound();
    }

    private void playImpactSound()
    {
        int index = Random.Range(0, impactSFXs.Length);
        impactClip = impactSFXs[index];
        impactSource.clip = impactClip;
        impactSource.Play();
    }
}
