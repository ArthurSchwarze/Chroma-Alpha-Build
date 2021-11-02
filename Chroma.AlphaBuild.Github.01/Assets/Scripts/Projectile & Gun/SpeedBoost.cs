using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    GameObject firstPersonPlayer;
    NewPlayerMovement speedTrigger;

    private void Start()
    {
        firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        speedTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottom"))
        {
            if (speedTrigger.canJump == false)
            {
                speedTrigger.MaxSpeedInAir = 33f;
                speedTrigger.groundSpeed = 33f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bottom"))
        {
            if (speedTrigger.canJump == false)
            {
                speedTrigger.MaxSpeedInAir = 33f;
                speedTrigger.groundSpeed = 33f;
            }
        }
    }
}
