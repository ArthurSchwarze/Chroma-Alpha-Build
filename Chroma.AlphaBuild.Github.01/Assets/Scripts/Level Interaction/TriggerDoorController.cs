using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
    [SerializeField] private Animator myDoor = null;

    [SerializeField] int howManyCubesToOpen = 1;

    [SerializeField] static private int openNumber = 0;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.GetComponent<GravityGameObject>())
        {
            openNumber++;
            MoveDoor();
        }

        /*
        else if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            MoveDoor();
            Debug.Log("Player");
        }
        */

        if (LayerMask.NameToLayer("Object") == collision.gameObject.layer)
        {
            return;
        }

        openNumber++;
        MoveDoor();

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<GravityGameObject>())
        {
            openNumber--;
            MoveDoor();
        }

        if (LayerMask.NameToLayer("Object") == collision.gameObject.layer)
        {
            return;
        }

        openNumber--;
        MoveDoor();


    }

    private void MoveDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (openNumber == 0)
        {
            if (time < 1.0f)
            {
                myDoor.Play("DoorClose", 0, 1.0f - time);
                return;
            }

            myDoor.Play("DoorClose", 0, 0.0f);
        }

        else if (openNumber == howManyCubesToOpen)
        {
            if (time < 1.0f)
            {
                myDoor.Play("DoorOpen", 0, 1.0f - time);
                return;
            }
            myDoor.Play("DoorOpen", 0, 0.0f);
        }

    }
}
