using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))// || other.CompareTag("Cube") || other.CompareTag("ignoreCollision"))
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
        //if (other.CompareTag("Cube") || other.CompareTag("ignoreCollision"))
        //{
        //    other.transform.SetParent(GameObject.Find("MoveableObjects").transform);
        //}
    }
}
