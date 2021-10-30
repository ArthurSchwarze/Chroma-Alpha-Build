using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorEnter : MonoBehaviour
{
    [HideInInspector]
    public bool isEntered;

    private void OnTriggerStay(Collider other)
    {
        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom") || (other.gameObject.tag == "Body"))
        {
            isEntered = true;
        }
    }
}
