using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    Vector3 lastPosition, lastMove;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            other.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            other.transform.SetParent(null);
        }
    }

    void FixedUpdate()
    {
        lastMove = transform.position - lastPosition;
        lastPosition = transform.position;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Cube") || other.CompareTag("ignoreCollision"))
        {
            other.attachedRigidbody.MovePosition(other.attachedRigidbody.position + lastMove);
        }
    }
}
