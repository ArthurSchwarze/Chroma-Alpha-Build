using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float gravityMultiplyer = 1.5f;
    public float jumpHeight = 3f;

    public float StopX = 0;
    public float StopZ = 0;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    public LayerMask objectMask;

    public Vector3 velocity;
    public bool isGrounded;
    public bool isOnObject;
    float playerGravity;

    private float changerTime = 0f;

    public bool canJump = false;

    public Vector3 moveXYZ;


    // Start is called before the first frame update
    void Start()
    {
        playerGravity = gravity * gravityMultiplyer;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isOnObject = Physics.CheckSphere(groundCheck.position, groundDistance, objectMask);

        controller.Move(moveXYZ * Time.deltaTime);
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        //if ((CheckPositive(move.x) != -StopX) && StopX != 0)
        //{
            //move = new Vector3(0, move.y, move.z);
            //GetComponent<PickAndDrop>().stopXMovement = true;
        //}
        //else 
        //{
            //GetComponent<PickAndDrop>().stopXMovement = false;
        //}

        //if ((CheckPositive(move.z) != -StopZ) && StopZ != 0)
        //{
            //move = new Vector3(move.x, move.y, 0);
            //GetComponent<PickAndDrop>().stopZMovement = true;
        //}
        //else 
        //{
            //GetComponent<PickAndDrop>().stopZMovement = false;
        //}


        //controller.Move(move * speed * Time.deltaTime);
        Vector3 moveXZ = move * speed;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * playerGravity);
        }

        //velocity.y += playerGravity * Time.deltaTime;
        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f * gravityMultiplyer;
        }
        else 
        {
            velocity.y += playerGravity * Time.deltaTime;
        }
        
        //controller.Move(velocity * Time.deltaTime);

        moveXYZ = new Vector3(moveXZ.x, velocity.y, moveXZ.z);

        //controller.Move(moveXYZ * Time.deltaTime);

        if (changerTime != 0) 
        {
            if (Time.time - changerTime > 1) 
            {
                speed = 12f;
                changerTime = 0;

            }
        }

    }

    private float CheckPositive(float number)
    {
        if (number == 0)
        {
            return (0);
        }
        return (Mathf.Sign(number));
    }

    public void SpeedCountDown() 
    {
        changerTime = Time.time;
    }
}
