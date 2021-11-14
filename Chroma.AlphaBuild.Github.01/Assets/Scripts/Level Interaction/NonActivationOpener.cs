using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonActivationOpener : MonoBehaviour
{
    [SerializeField] Animator myDoor = null;
    [SerializeField] AudioSource confirmationSFX;

    private bool oneTime;
    private bool oneTime2;
    private bool firstTime = true;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("ignoreCollision"))
        {
            if (!oneTime)
            {
                OpenDoor();
                oneTime = true;
                oneTime2 = false;
            }
        }

        if (collision.collider.CompareTag("Cube"))
        {
            if (!oneTime2)
            {
                CloseDoor();
                oneTime2 = true;
                oneTime = false;

                firstTime = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Cube"))
        {
            OpenDoor();
            oneTime = true;
            oneTime2 = false;
        }
    }

    void CloseDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (time < 1.0f)
        {
            myDoor.Play("DoorClose", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorClose", 0, 0.0f);
    }

    void OpenDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (!firstTime)
        {
            Invoke("PlaySound", .2f);
        }

        if (time < 1.0f)
        {
            myDoor.Play("DoorOpen", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorOpen", 0, 0.0f);
    }

    void PlaySound()
    {
        confirmationSFX.Play();
    }
}
