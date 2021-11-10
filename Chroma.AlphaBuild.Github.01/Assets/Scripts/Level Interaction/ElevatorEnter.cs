using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEnter : MonoBehaviour
{
    [HideInInspector]
    public bool isEntered;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Head") || other.CompareTag("Bottom") || other.CompareTag("Body"))
        {
            isEntered = true;
        }
    }
}
