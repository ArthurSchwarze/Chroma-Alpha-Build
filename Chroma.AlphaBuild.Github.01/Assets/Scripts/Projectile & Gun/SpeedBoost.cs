using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement speedTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        if (other.gameObject.tag == "Bottom")
        {
            if (speedTrigger.canJump == false)
            {
                speedTrigger.MaxSpeedInAir = 34f;
                speedTrigger.groundSpeed = 34f;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement speedTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        if (other.gameObject.tag == "Bottom")
        {
            if (speedTrigger.canJump == false)
            {
                speedTrigger.MaxSpeedInAir = 34f;
                speedTrigger.groundSpeed = 34f;
            }
        }
    }
}
