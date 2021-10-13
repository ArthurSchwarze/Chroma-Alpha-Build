using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour
{
    private AudioSource footSource;
    public AudioClip[] footSFXs;
    private AudioClip footClip;

    private NewPlayerMovement walktype;

    // Start is called before the first frame update
    void Start()
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        walktype = firstPersonPlayer.GetComponent<NewPlayerMovement>();
        footSource = this.GetComponent<AudioSource>();
    }

    private void playFootSound1()
    {
        if (walktype.walks)
        {
            int index = Random.Range(0, footSFXs.Length);
            footClip = footSFXs[index];
            footSource.clip = footClip;
            footSource.Play();
        }
    }

    private void playFootSound2()
    {
        if (walktype.runs)
        {
            int index = Random.Range(0, footSFXs.Length);
            footClip = footSFXs[index];
            footSource.clip = footClip;
            footSource.Play();
        }
    }
}
