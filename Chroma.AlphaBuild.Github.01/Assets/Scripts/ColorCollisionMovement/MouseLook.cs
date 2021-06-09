using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    public float LimitRotationY = 0; 

    private float xRotation = 0f; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        int LimitY = 1;
        //int LimitX = 1;

        float axisY = Input.GetAxis("Mouse Y");
        float axisX = Input.GetAxis("Mouse X");


        if (Input.GetKey(KeyCode.L)) 
        {
            Debug.Log("Limit: " + LimitRotationY + " Mouse: " + (axisY / Mathf.Abs(axisY)));
        }
        
        if (-LimitRotationY != (CheckPositive(axisY)) && LimitRotationY != 0)
        {
            LimitY = 0;
        }
        transform.parent.GetComponent<PickAndDrop>().stopYMovement = LimitY;

        float mouseX = axisX * mouseSensitivity * Time.deltaTime;
        float mouseY = axisY * mouseSensitivity * Time.deltaTime * LimitY;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        

        playerBody.Rotate(Vector3.up * mouseX);
    }

    // FixedUpdate is calles once every physics update
    private void FixedUpdate()
    {
        
    }

    private float CheckPositive(float number)
    {
        if (number == 0)
        {
            return (0);
        }
        return (Mathf.Sign(number));
    }

}
