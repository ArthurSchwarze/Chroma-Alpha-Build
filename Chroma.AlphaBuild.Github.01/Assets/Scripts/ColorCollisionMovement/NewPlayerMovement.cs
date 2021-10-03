using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [Header("General")]
    [Tooltip("Force applied downward when in the air")]
    public float GravityDownForce = 20f;

    [Header("Movement")]
    [Tooltip("How fast on ground?")]
    public float groundSpeed = 10f;

    [Tooltip("Sharpness for the movement when grounded, a low value will make the player accelerate and decelerate slowly, a high value will do the opposite")]
    public float MovementSharpnessOnGround = 15;

    [Header("Jump")]
    [Tooltip("Force applied upward when jumping")]
    public float JumpForce = 9f;

    [Tooltip("Acceleration speed when in the air")]
    public float AccelerationSpeedInAir = 25f;

    [Tooltip("Max movement speed when not grounded")]
    public float MaxSpeedInAir = 10f;

    public Vector3 CharacterVelocity { get; set; }

    [HideInInspector]
    public bool canJump;
    [HideInInspector]
    public bool canBounce;

    float lastGroundedTime;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Vector3 inputDir = new Vector3(input.x, 0, input.y).normalized;
        Vector3 worldInputDir = transform.TransformDirection(inputDir);

        var flags = controller.Move(CharacterVelocity * Time.deltaTime);

        // handle grounded movement
        if ((flags & CollisionFlags.Below) != 0)
        {
            controller.slopeLimit = 40f;
            canJump = true;
            lastGroundedTime = Time.time;

            Vector3 targetVelocity = worldInputDir * groundSpeed;

            // smoothly interpolate between our current velocity and the target velocity based on acceleration speed
            CharacterVelocity = Vector3.Lerp(CharacterVelocity, targetVelocity, MovementSharpnessOnGround * Time.deltaTime);
        }

        // to prevent that momentum is still going on when hitting against a wall, canBounce is for Bounce Script for ignoring this or not
        if ((flags == CollisionFlags.Sides) && (canBounce == false))
        {
            CharacterVelocity = new Vector3(controller.velocity.x, CharacterVelocity.y, controller.velocity.z);
        }

        if ((groundSpeed > 13) || (MaxSpeedInAir > 13))
        {
            groundSpeed -= 10f * Time.deltaTime;
            MaxSpeedInAir -= 10f * Time.deltaTime;
        }

        // jumping
        if (Input.GetButtonDown("Jump"))
        {
            // preventing to jack up on edges
            controller.slopeLimit = 90f;

            float timeSinceLastTouchedGround = Time.time - lastGroundedTime;
            if (controller.isGrounded || (canJump && timeSinceLastTouchedGround < 0.15f))
            {
                canJump = false;

                // start by canceling out the vertical component of our velocity
                CharacterVelocity = new Vector3(CharacterVelocity.x, 0f, CharacterVelocity.z);

                // then, add the jumpSpeed value upwards
                CharacterVelocity += Vector3.up * JumpForce;
            }
        }

        // in air
        else
        {
            canJump = false;

            // add air acceleration
            CharacterVelocity += worldInputDir * AccelerationSpeedInAir * Time.deltaTime;

            // limit air speed to a maximum, but only horizontally
            float verticalVelocity = CharacterVelocity.y;
            Vector3 horizontalVelocity = Vector3.ProjectOnPlane(CharacterVelocity, Vector3.up);
            horizontalVelocity = Vector3.ClampMagnitude(horizontalVelocity, MaxSpeedInAir);
            CharacterVelocity = horizontalVelocity + (Vector3.up * verticalVelocity);

            // apply the gravity to the velocity
            CharacterVelocity += Vector3.down * GravityDownForce * Time.deltaTime;
        }
    }
}
