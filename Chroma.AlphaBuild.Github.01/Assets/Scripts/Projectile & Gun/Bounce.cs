using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    GameObject firstPersonPlayer;
    NewPlayerMovement bounceTrigger;

    private float magnitude;

    private AudioSource bounceSource;
    public AudioClip[] bounceSFXs;
    private AudioClip bounceClip;

    private void Start()
    {
        firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        bounceSource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bounceTrigger.canBounce = true;
        bounceTrigger.canJump = false;

        // limit bounce force
        if (bounceTrigger.CharacterVelocity.magnitude > 26f)
        {
            magnitude = 26f;
        }
        else if (bounceTrigger.CharacterVelocity.magnitude <= 26f)
        {
            magnitude = bounceTrigger.CharacterVelocity.magnitude;
        }


        if (other.CompareTag("Head") || other.CompareTag("Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);
        }

        if (other.CompareTag("Body"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        bounceTrigger.canBounce = true;
        bounceTrigger.canJump = false;

        // limit bounce force
        if (bounceTrigger.CharacterVelocity.magnitude > 26f)
        {
            magnitude = 26f;
        }
        else if (bounceTrigger.CharacterVelocity.magnitude <= 26f)
        {
            magnitude = bounceTrigger.CharacterVelocity.magnitude;
        }


        if (other.CompareTag("Head") || other.CompareTag("Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);
        }

        if (other.CompareTag("Body"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bounceTrigger.canBounce = false;

        if (other.CompareTag("Body") || other.CompareTag("Head") || other.CompareTag("Bottom"))
        {
            playBounceSound();
        }
    }

    private void playBounceSound()
    {
        int index = Random.Range(0, bounceSFXs.Length);
        bounceClip = bounceSFXs[index];
        bounceSource.clip = bounceClip;
        bounceSource.Play();
    }
}
