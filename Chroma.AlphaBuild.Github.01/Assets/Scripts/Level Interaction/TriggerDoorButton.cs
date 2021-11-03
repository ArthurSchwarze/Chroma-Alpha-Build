using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorButton : MonoBehaviour
{
    [HideInInspector] public bool triggered;
    [HideInInspector] public bool stays;

    private AudioSource buttonSource;
    [SerializeField] AudioClip[] buttonSFXs;
    private AudioClip buttonClip;

    private void Start()
    {
        buttonSource = this.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ignoreCollision") && collision.gameObject.CompareTag("Cube"))
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
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ignoreCollision") && collision.gameObject.CompareTag("Cube"))
        {
            if (!stays)
            {
                PlayButtonSound();
            }

            if (collision.gameObject.GetComponent<GravityGameObject>())
            {
                stays = true;
            }

            stays = true;
        }

        else if (collision.gameObject.CompareTag("ignoreCollision"))
        {
            stays = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag("ignoreCollision") && collision.gameObject.CompareTag("Cube"))
        {
            if (collision.gameObject.GetComponent<GravityGameObject>())
            {
                triggered = false;
                stays = false;
            }

            triggered = false;
            stays = false;
        }

        else if (collision.gameObject.CompareTag("ignoreCollision"))
        {
            triggered = false;
            stays = false;
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
