using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGameObject : MonoBehaviour
{
    public CharacterController controller;

    public bool useGravity;
    public bool temporaryBreak = false;

    public bool isGrounded = true;
    public bool isMooving = false;

    public float gravityModifier = 1;

    public Rigidbody rb;
    
    private GameObject character;
    private GameObject mainCamera;

    public int countCollisions = 1;
    public int countAllCollisions = 0;

    Vector3 worldPosition;

    public Vector3 acceleration = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;

        character = GameObject.Find("FirstPersonPlayer");

        mainCamera = GameObject.FindWithTag("MainCamera");
    }

    void FixedUpdate()
    {
        if (MinimalVector(worldPosition - transform.position)) 
        {
            isMooving = false;
        }
        else 
        {
            isMooving = true;
        }
        
        worldPosition = transform.position;
        
        if (!temporaryBreak && (!isGrounded || isMooving)) //|| rb.velocity != Vector3.zero
        {
            rb.AddForce(Vector3.down * 9.81f * gravityModifier * Time.deltaTime, ForceMode.VelocityChange);
            //GetComponent<Rigidbody>().useGravity = true;
        }
        else 
        {
            //GetComponent<Rigidbody>().useGravity = false;
            if (!temporaryBreak)
            {
                rb.velocity = (Vector3.down * gravityModifier * 0.05f);
            }
        }

        acceleration = rb.velocity;

        //if (countCollisions == 20)
        //{
            //character.GetComponent<PlayerMovement>().StopX = 0;
            //character.GetComponent<PlayerMovement>().StopZ = 0;
            //mainCamera.GetComponent<MouseLook>().LimitRotationY = 0;
        //}

        //if ((countAllCollisions == 0 || countAllCollisions == 1) && !temporaryBreak) 
        //{
            //GetComponent<Rigidbody>().freezeRotation = true;
        //}
        //else 
        //{
            //GetComponent<Rigidbody>().freezeRotation = false;
        //}
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.rigidbody);
        countAllCollisions += 1;

        if (collision.gameObject.layer == 3)
        {
            isGrounded = true;
        }

        //if (temporaryBreak)
        //{
            //countCollisions += 1;

            //Vector3 FirstPoint = collision.GetContact(0).point - transform.position;
            //Vector3 MiddlePoint = collision.GetContact(collision.contactCount / 2 - 1).point - transform.position;
            //Vector3 SecondMiddlePoint = collision.GetContact(collision.contactCount / 2).point - transform.position;
            //Vector3 LastPoint = collision.GetContact(collision.contactCount - 1).point - transform.position;

            //if (FirstPoint.x == LastPoint.x && FirstPoint.x == MiddlePoint.x && FirstPoint.x == SecondMiddlePoint.x)
            //{
                //float changeX = Mathf.Sign(FirstPoint.x);
                //Debug.Log("x: " + Mathf.Sign(FirstPoint.x));
                //Debug.Log(changeX);
                //character.GetComponent<PlayerMovement>().StopX = changeX;
            //}

            //if (FirstPoint.y == LastPoint.y && FirstPoint.y == MiddlePoint.y && FirstPoint.y == SecondMiddlePoint.y)
            //{
                //float changeY = Mathf.Sign(FirstPoint.y);
                //Debug.Log("y: " + changeY);
                //Debug.Log(FirstPoint + " + " + MiddlePoint + " + " + LastPoint);
                //Debug.Log("Contact points: " + collision.contactCount);
                //mainCamera.GetComponent<MouseLook>().LimitRotationY = changeY;
            //}

            //if (FirstPoint.z == LastPoint.z && FirstPoint.z == MiddlePoint.z && FirstPoint.z == SecondMiddlePoint.z)
            //{
                //float changeZ = Mathf.Sign(FirstPoint.z);
                //Debug.Log("z: " + changeZ);
                //Debug.Log(changeZ);
                //character.GetComponent<PlayerMovement>().StopZ = changeZ;
            //}
        //}
    }

    private void OnCollisionExit(Collision collision)
    {
       
        countAllCollisions -= 1;

        if (collision.gameObject.layer == 3 && isGrounded)
        {
            isGrounded = false;
        }

        //if (temporaryBreak)
        //{
            //countCollisions -= 1;

            //if (character.GetComponent<PlayerMovement>().StopX != )
            //character.GetComponent<PlayerMovement>().StopX = 0;
            //character.GetComponent<PlayerMovement>().StopZ = 0;
            //mainCamera.GetComponent<MouseLook>().LimitRotationY = 0;

            //Vector3 blockMovement = character.GetComponent<PickAndDrop>().actualMovement;

            //float objectStopX = character.GetComponent<PlayerMovement>().StopX;
            //float objectStopZ = character.GetComponent<PlayerMovement>().StopZ;

            //if (blockMovement.x != 0 && (CheckPositive(blockMovement.x) != objectStopX) && objectStopX != 0)
            //{
                //character.GetComponent<PlayerMovement>().StopX = 0;
            //}

            //if (blockMovement.z != 0 && (CheckPositive(blockMovement.z) != objectStopZ) && objectStopZ != 0)
            //{
                //character.GetComponent<PlayerMovement>().StopZ = 0;
            //}

            //Debug.Log("Collision Count: " + countCollsions);
        //}
        
    }


    public void ColorChangeGravity() 
    {
        isGrounded = false;
    }
   

    private float CheckPositive(float number)
    {
        if (number == 0)
        {
            return (0);
        }
        return (Mathf.Sign(number));
    }

    private bool MinimalVector(Vector3 v) 
    {
        if ((Mathf.Abs(v.x) < 0.005) && (Mathf.Abs(v.y) < 0.005) && (Mathf.Abs(v.z) < 0.005))
        {
            return true;
        }
        return false;
    }
}
