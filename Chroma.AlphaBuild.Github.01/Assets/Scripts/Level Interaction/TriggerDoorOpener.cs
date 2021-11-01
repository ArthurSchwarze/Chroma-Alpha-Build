using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpener : MonoBehaviour
{
    public TriggerDoorButton cylinder1;
    public TriggerDoorButton cylinder2;
    public TriggerDoorButton cylinder3;
    public TriggerDoorButton cylinder4;

    public bool cylinder1_2NotConnected; // if the 2 Buttons are independent or not (like in LVL 1 the first door)

    [SerializeField] Animator myDoor = null;

    bool oneTime;

    private void FixedUpdate()
    {
        // 1 Button
        if (cylinder1 && !cylinder2 && !cylinder3 && !cylinder4)
        {
            if (cylinder1.triggered)
            {
                OpenDoor();
                ResetTriggers1();
            }

            if (!cylinder1.stays)
            {
                ResetTriggers1();
            }

            else if (cylinder1.exitTriggered)
            {
                CloseDoor();
                ResetTriggers1();
            }
        }
        
        // 2 Buttons
        else if (cylinder1 && cylinder2 && !cylinder3 && !cylinder4)
        {
            // dependent Buttons
            if (!cylinder1_2NotConnected)
            {
                if ((cylinder1.triggered && cylinder2.triggered) || (cylinder1.triggered && cylinder2.stays) || (cylinder1.stays && cylinder2.triggered))
                {
                    OpenDoor();
                    ResetTriggers2();
                }

                if (!cylinder1.stays && !cylinder2.stays)
                {
                    ResetTriggers2();
                }

                else if ((cylinder1.exitTriggered && cylinder2.stays) || (cylinder1.stays && cylinder2.exitTriggered))
                {
                    CloseDoor();
                    ResetTriggers2();
                }
            }

            // independent Buttons
            else if (cylinder1_2NotConnected)
            {
                if ((cylinder1.triggered && !cylinder2.stays && !oneTime) || (!cylinder1.stays && cylinder2.triggered && !oneTime))
                {
                    OpenDoor();
                    ResetTriggers2();
                    oneTime = true;
                }

                else if (!cylinder1.stays && !cylinder2.stays && oneTime)
                {
                    CloseDoor();
                    ResetTriggers2();
                    oneTime = false;
                }
            }
        }
        /*
        // 3 Buttons
        else if (cylinder1 && cylinder2 && cylinder3 && !cylinder4)
        {
            if (cylinder1.triggered + cylinder2.triggered + cylinder3.triggered == 6)
            {
                OpenDoor();
                cylinder1.triggered = 0;
                cylinder2.triggered = 0;
                cylinder3.triggered = 0;
            }

            else if (cylinder1.triggered + cylinder2.triggered + cylinder3.triggered < 6)
            {
                CloseDoor();
                cylinder1.triggered = 0;
                cylinder2.triggered = 0;
                cylinder3.triggered = 0;
            }
        }

        // 4 Buttons
        else if (cylinder1 && cylinder2 && cylinder3 && cylinder4)
        {
            if (cylinder1.triggered + cylinder2.triggered + cylinder3.triggered + cylinder4.triggered == 8)
            {
                OpenDoor();
                cylinder1.triggered = 0;
                cylinder2.triggered = 0;
                cylinder3.triggered = 0;
                cylinder4.triggered = 0;
            }

            else if (cylinder1.triggered + cylinder2.triggered + cylinder3.triggered + cylinder4.triggered < 8)
            {
                CloseDoor();
                cylinder1.triggered = 0;
                cylinder2.triggered = 0;
                cylinder3.triggered = 0;
                cylinder4.triggered = 0;
            }
        }
        */
    }

    void ResetTriggers1()
    {
        cylinder1.triggered = false;
        cylinder1.exitTriggered = false;
        cylinder1.stays = false;
    }
    void ResetTriggers2()
    {
        cylinder1.triggered = false;
        cylinder1.exitTriggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.exitTriggered = false;
        cylinder2.stays = false;
    }
    void ResetTriggers3()
    {
        cylinder1.triggered = false;
        cylinder1.exitTriggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.exitTriggered = false;
        cylinder2.stays = false;

        cylinder3.triggered = false;
        cylinder3.exitTriggered = false;
        cylinder3.stays = false;
    }
    void ResetTriggers4()
    {
        cylinder1.triggered = false;
        cylinder1.exitTriggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.exitTriggered = false;
        cylinder2.stays = false;

        cylinder3.triggered = false;
        cylinder3.exitTriggered = false;
        cylinder3.stays = false;

        cylinder4.triggered = false;
        cylinder4.exitTriggered = false;
        cylinder4.stays = false;
    }

    void CloseDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (time < 1.0f)
        {
            myDoor.Play("DoorClose", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorClose", 0, 0.0f);
    }

    void OpenDoor()
    {
        float time = myDoor.GetCurrentAnimatorStateInfo(0).normalizedTime;

        if (time < 1.0f)
        {
            myDoor.Play("DoorOpen", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorOpen", 0, 0.0f);
    }
}
