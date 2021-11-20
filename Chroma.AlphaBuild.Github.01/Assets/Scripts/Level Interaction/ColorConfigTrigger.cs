using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorConfigTrigger : MonoBehaviour
{
    private ColorActivation colorActivation;

    private void Awake()
    {
        colorActivation = GameObject.Find("FirstPersonPlayer").GetComponent<ColorActivation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            colorActivation.blue = true;
            colorActivation.red = true;
            colorActivation.yellow = false;
            colorActivation.green = false;
        }
    }
}
