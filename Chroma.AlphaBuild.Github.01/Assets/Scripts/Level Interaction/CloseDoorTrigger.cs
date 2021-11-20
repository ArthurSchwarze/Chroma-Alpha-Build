using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    [SerializeField] Animator myDoor = null;
    private bool oneTime;

    [SerializeField] GameObject invisibleWall;

    private void Start()
    {
        OpenDoor();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!oneTime && other.CompareTag("PlayerBody"))
        {
            invisibleWall.SetActive(true);
            CloseDoor();
            oneTime = true;
        }
    }

    void OpenDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (time < 1.0f)
        {
            myDoor.Play("DoorOpen", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorOpen", 0, 0.0f);
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
}
