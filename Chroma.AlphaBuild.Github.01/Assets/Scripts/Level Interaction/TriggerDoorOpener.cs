using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorOpener : MonoBehaviour
{
    [Header("Which Buttons?")]
    public TriggerDoorButton cylinder1;
    public TriggerDoorButton cylinder2;
    public TriggerDoorButton cylinder3;
    public TriggerDoorButton cylinder4;

    [Space]

    public bool cylinder1_2NotConnected; // if the 2 Buttons are independent or not
    [Tooltip("after opening the door it will not close anymore or platform keeps running")] public bool keepDoorOpen;

    [Space]

    [SerializeField] AudioSource confirmationSFX;
    [SerializeField] Animator myDoor = null;
    [SerializeField] BlockDisplacement myPlatform = null;

    [HideInInspector] public bool makeSound;
    bool oneTime;
    bool notClosed;

    private delegate void Delegate();

    private Delegate Function1;
    private Delegate Function2;

    private void Start()
    {
        if (myDoor && !myPlatform) // if buttons are for a door
        {
            Function1 = OpenDoor;
            Function2 = CloseDoor;
        }

        else if (myPlatform && ! myDoor) // if buttons are for a platform
        {
            myPlatform.enabled = false;
            Function1 = StartPlatform;
            Function2 = StopPlatform;
        }
    }

    private void FixedUpdate()
    {
        #region OneButton
        // 1 Button
        if (cylinder1 && !cylinder2 && !cylinder3 && !cylinder4)
        {
            if ((cylinder1.triggered && !oneTime) || (cylinder1.stays && !oneTime))
            {
                Function1();
                //ResetTriggers1();
                oneTime = true;
                if (keepDoorOpen)
                {
                    notClosed = true;
                }
            }

            if (cylinder1.triggered || cylinder1.stays)
            {
                if (!notClosed)
                {
                    makeSound = true;
                }
            }

            if (!cylinder1.stays && oneTime && !keepDoorOpen)
            {
                Function2();
                ResetTriggers1();
                oneTime = false;
            }
        }
        #endregion

        #region TwoButtons
        // 2 Buttons
        else if (cylinder1 && cylinder2 && !cylinder3 && !cylinder4)
        {
            // dependent Buttons
            if (!cylinder1_2NotConnected)
            {
                if ((cylinder1.triggered && cylinder2.triggered && !oneTime) || (cylinder1.stays && cylinder2.stays && !oneTime) || (cylinder1.triggered && cylinder2.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.triggered && !oneTime && !keepDoorOpen))
                {
                    Function1();
                    //ResetTriggers2();
                    oneTime = true;
                    if (keepDoorOpen)
                    {
                        notClosed = true;
                    }
                }
                
                if ((!cylinder1.stays && cylinder2.stays) || (cylinder1.stays && !cylinder2.stays) || (cylinder1.stays && cylinder2.stays))
                {
                    if (!notClosed)
                    {
                        makeSound = true;
                    }
                }
                
                if ((!cylinder1.stays && cylinder2.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && !cylinder2.stays && oneTime && !keepDoorOpen))
                {
                    Function2();
                    ResetTriggers2();
                    oneTime = false;
                }
            }

            // independent Buttons (implementing keepDoorOpen variabel here doesn't make sense)
            else if (cylinder1_2NotConnected)
            {
                if ((cylinder1.triggered && !cylinder2.stays && !oneTime) || (!cylinder1.stays && cylinder2.triggered && !oneTime) || (cylinder1.stays && !cylinder2.stays && !oneTime) || (!cylinder1.stays && cylinder2.stays && !oneTime) || (cylinder1.stays && cylinder2.stays && !oneTime))
                {
                    Function1();
                    //ResetTriggers2();
                    oneTime = true;
                }

                else if (!cylinder1.stays && !cylinder2.stays && oneTime)
                {
                    Function2();
                    ResetTriggers2();
                    oneTime = false;
                }

                if ((cylinder1.triggered && !cylinder2.stays) || (!cylinder1.stays && cylinder2.triggered) || (cylinder1.stays && !cylinder2.stays) || (!cylinder1.stays && cylinder2.stays) || (cylinder1.stays && cylinder2.stays))
                {
                    makeSound = true;
                }
            }
        }
        #endregion

        #region ThreeButtons
        // 3 Buttons
        else if (cylinder1 && cylinder2 && cylinder3 && !cylinder4)
        {
            if ((cylinder1.triggered && cylinder2.triggered && cylinder3.triggered && !oneTime) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && !oneTime) || (cylinder1.triggered && cylinder2.stays && cylinder3.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.triggered && cylinder3.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && cylinder3.triggered && !oneTime && !keepDoorOpen))
            {
                Function1();
                //ResetTriggers3();
                oneTime = true;
                if (keepDoorOpen)
                {
                    notClosed = true;
                }
            }

            if ((!cylinder1.stays && cylinder2.stays && cylinder3.stays) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays) || (cylinder1.stays && !cylinder2.stays && !cylinder3.stays) || (!cylinder1.stays && cylinder2.stays && !cylinder3.stays) || (!cylinder1.stays && !cylinder2.stays && cylinder3.stays) || (cylinder1.stays && cylinder2.stays && cylinder3.stays))
            {
                if (!notClosed)
                {
                    makeSound = true;
                }
            }

            if ((!cylinder1.stays && cylinder2.stays && cylinder3.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && !cylinder3.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && cylinder2.stays && !cylinder3.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && !cylinder2.stays && cylinder3.stays && oneTime && !keepDoorOpen))
            {
                Function2();
                ResetTriggers3();
                oneTime = false;
            }
        }
        #endregion

        #region FourButtons
        // 4 Buttons
        else if (cylinder1 && cylinder2 && cylinder3 && cylinder4)
        {
            if ((cylinder1.triggered && cylinder2.triggered && cylinder3.triggered && cylinder4.triggered && !oneTime) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && cylinder4.stays && !oneTime) || (cylinder1.triggered && cylinder2.stays && cylinder3.stays && cylinder4.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.triggered && cylinder3.stays && cylinder4.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && cylinder3.triggered && cylinder4.stays && !oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && cylinder4.triggered && !oneTime && !keepDoorOpen))
            {
                Function1();
                //ResetTriggers4();
                oneTime = true;
                if (keepDoorOpen)
                {
                    notClosed = true;
                }
            }

            if ((!cylinder1.stays && !cylinder2.stays && cylinder3.stays && cylinder4.stays) || (!cylinder1.stays && cylinder2.stays && !cylinder3.stays && cylinder4.stays) || (!cylinder1.stays && cylinder2.stays && cylinder3.stays && !cylinder4.stays) || (cylinder1.stays && !cylinder2.stays && !cylinder3.stays && cylinder4.stays) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays && !cylinder4.stays) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays && !cylinder4.stays) || (cylinder1.stays && !cylinder2.stays && !cylinder3.stays && !cylinder4.stays) || (!cylinder1.stays && !cylinder2.stays && !cylinder3.stays && cylinder4.stays) || (!cylinder1.stays && !cylinder2.stays && cylinder3.stays && !cylinder4.stays) || (!cylinder1.stays && cylinder2.stays && !cylinder3.stays && !cylinder4.stays) || (!cylinder1.stays && cylinder2.stays && cylinder3.stays && cylinder4.stays) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays && cylinder4.stays) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays && cylinder4.stays) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && !cylinder4.stays) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && cylinder4.stays))
            {
                if (!notClosed)
                {
                    makeSound = true;
                }
            }

            if ((!cylinder1.stays && cylinder2.stays && cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && cylinder3.stays && !cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && cylinder2.stays && !cylinder3.stays && !cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && cylinder3.stays && !cylinder4.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && cylinder2.stays && cylinder3.stays && !cylinder4.stays && oneTime && !keepDoorOpen) || (cylinder1.stays && !cylinder2.stays && !cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && cylinder2.stays && !cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen) || (!cylinder1.stays && !cylinder2.stays && cylinder3.stays && cylinder4.stays && oneTime && !keepDoorOpen))
            {
                Function2();
                ResetTriggers4();
                oneTime = false;
            }
        }
        #endregion
    }

    #region ResetTriggers
    void ResetTriggers1()
    {
        cylinder1.triggered = false;
        cylinder1.stays = false;
    }
    void ResetTriggers2()
    {
        cylinder1.triggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.stays = false;
    }
    void ResetTriggers3()
    {
        cylinder1.triggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.stays = false;

        cylinder3.triggered = false;
        cylinder3.stays = false;
    }
    void ResetTriggers4()
    {
        cylinder1.triggered = false;
        cylinder1.stays = false;

        cylinder2.triggered = false;
        cylinder2.stays = false;

        cylinder3.triggered = false;
        cylinder3.stays = false;

        cylinder4.triggered = false;
        cylinder4.stays = false;
    }
    #endregion

    #region DoorAction
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

        Invoke("PlaySound", .2f);

        if (time < 1.0f)
        {
            myDoor.Play("DoorOpen", 0, 1.0f - time);
            return;
        }

        myDoor.Play("DoorOpen", 0, 0.0f);
    }
    #endregion

    #region PlatformAction
    void StartPlatform()
    {
        Invoke("PlaySound", .2f);
        myPlatform.enabled = true;
    }

    void StopPlatform()
    {
        myPlatform.enabled = false;
    }
    #endregion

    void PlaySound()
    {
        confirmationSFX.Play();
    }
}
