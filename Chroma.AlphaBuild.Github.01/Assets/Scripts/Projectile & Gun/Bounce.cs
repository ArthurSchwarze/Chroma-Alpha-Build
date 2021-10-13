using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private float magnitude;

    private AudioSource bounceSource;
    public AudioClip[] bounceSFXs;
    private AudioClip bounceClip;

    private void Start()
    {
        bounceSource = this.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

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


        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

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


        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        bounceTrigger.canBounce = false;

        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom") || (other.gameObject.tag == "Body"))
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
