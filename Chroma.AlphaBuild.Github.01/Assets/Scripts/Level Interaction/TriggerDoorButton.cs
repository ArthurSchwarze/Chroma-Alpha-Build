using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorButton : MonoBehaviour
{
    [HideInInspector] public bool triggered;
    [HideInInspector] public bool exitTriggered;
    [HideInInspector] public bool stays;

    private void OnCollisionEnter(Collision collision)
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

        if (LayerMask.NameToLayer("Object") == collision.gameObject.layer)
        {
            return;
        }

        triggered = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<GravityGameObject>())
        {
            stays = true;
        }

        if (LayerMask.NameToLayer("Object") == collision.gameObject.layer)
        {
            return;
        }

        stays = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<GravityGameObject>())
        {
            exitTriggered = true;
            stays = false;
        }

        if (LayerMask.NameToLayer("Object") == collision.gameObject.layer)
        {
            return;
        }

        exitTriggered = true;
        stays = false;
    }
}
