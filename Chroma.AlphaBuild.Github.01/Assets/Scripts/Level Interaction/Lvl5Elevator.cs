using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl5Elevator : MonoBehaviour
{
    [SerializeField] GameObject object1;
    [SerializeField] bool activate;

    private void OnTriggerEnter(Collider other)
    {
        object1.SetActive(activate);
    }
}
