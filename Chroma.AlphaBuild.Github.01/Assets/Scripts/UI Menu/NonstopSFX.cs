using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonstopSFX : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        audioSource.ignoreListenerPause = true;
    }
}
