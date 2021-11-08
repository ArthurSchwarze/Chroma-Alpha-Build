using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorButton : MonoBehaviour
{
    [HideInInspector] public bool triggered;
    [HideInInspector] public bool stays;
    bool exit = true;

    private AudioSource buttonSource;
    [SerializeField] AudioClip[] buttonSFXs;
    private AudioClip buttonClip;

    [SerializeField] TriggerDoorOpener opener;

    private void Start()
    {
        buttonSource = this.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<GravityGameObject>())
            {
                triggered = true;
            }

            /*
            else if (collision.gameObject.GetComponent<PlayerMovement>())
            {
                MoveDoor();
                Debug.Log("Player");
            }
            */

            triggered = true;
        }

        else if (collision.gameObject.CompareTag("ignoreCollision"))
        {
            triggered = false;
            stays = false;
            exit = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (opener.makeSound && exit)
            {
                PlayButtonSound();
                opener.makeSound = false;
                exit = false;
            }

            if (collision.gameObject.GetComponent<GravityGameObject>())
            {
                stays = true;
            }

            stays = true;
        }

        else if (collision.gameObject.CompareTag("ignoreCollision"))
        {
            triggered = false;
            stays = false;
            exit = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<GravityGameObject>())
            {
                triggered = false;
                stays = false;
                exit = true;
            }

            triggered = false;
            stays = false;
            exit = true;
        }

        else if (collision.gameObject.CompareTag("ignoreCollision"))
        {
            triggered = false;
            stays = false;
            exit = true;
        }
    }

    void PlayButtonSound()
    {
        int index = Random.Range(0, buttonSFXs.Length);
        buttonClip = buttonSFXs[index];
        buttonSource.clip = buttonClip;
        buttonSource.Play();
    }
}
