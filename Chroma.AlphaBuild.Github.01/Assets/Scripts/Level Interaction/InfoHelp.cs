using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoHelp : MonoBehaviour
{
    [SerializeField] private GameObject info;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("ActivateHelp", 7f);
    }

    void ActivateHelp()
    {
        info.SetActive(true);
    }
}
