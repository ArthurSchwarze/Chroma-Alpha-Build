using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipTrigger : MonoBehaviour
{
    GameObject blobSpawn;
    GameObject humanArms;
    GameObject body;
    GameObject gunSplatter;
    GameObject crosshair;
    GameObject image;
    GameObject colorSign;

    [HideInInspector]
    public bool equipped = false;

    private void Awake()
    {
        blobSpawn = GameObject.Find("Blob Spawn");
        humanArms = GameObject.Find("Human Arms");
        body = GameObject.FindWithTag("PGBody");
        gunSplatter = GameObject.Find("GunSplatter");
        crosshair = GameObject.Find("Crosshair");
        image = GameObject.Find("Image");
        colorSign = GameObject.FindWithTag("ColorSign");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (equipped == false)
        {
            deactivation();
        }

        if (equipped == true)
        {
            activation();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (equipped == false)
        {
            deactivation();
        }

        if (equipped == true)
        {
            activation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (equipped == false)
        {
            deactivation();
        }

        if (equipped == true)
        {
            activation();
        }
    }

    private void deactivation()
    {
        blobSpawn.SetActive(false);
        humanArms.SetActive(false);
        body.SetActive(false);
        gunSplatter.SetActive(false);
        crosshair.SetActive(false);
        image.SetActive(false);
        colorSign.SetActive(false);
    }
    private void activation()
    {
        blobSpawn.SetActive(true);
        humanArms.SetActive(true);
        body.SetActive(true);
        gunSplatter.SetActive(true);
        crosshair.SetActive(true);
        image.SetActive(true);
        colorSign.SetActive(true);
    }
}
