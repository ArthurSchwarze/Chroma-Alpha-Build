using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float swayPosAmount = .1f;
    public float swayRotAmount = 5f;

    public float smoothPosAmount = 8f;
    public float smoothRotAmount = 4f;

    public float maxPosAmount = .035f;
    public float maxRotAmount = 4f;

    private Vector3 initPos;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Position Sway
        float movementX = -Input.GetAxisRaw("Mouse X") * swayPosAmount;
        float movementY = -Input.GetAxisRaw("Mouse Y") * swayPosAmount;
        movementX = Mathf.Clamp(movementX, -maxPosAmount, maxPosAmount);
        movementY = Mathf.Clamp(movementY, -maxPosAmount, maxPosAmount);

        Vector3 finalPos = new Vector3(movementX, movementY, 0f);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + initPos, smoothPosAmount * Time.deltaTime);


        // Rotation Sway
        float mouseX = Input.GetAxisRaw("Mouse X") * swayRotAmount;
        float mouseY = Input.GetAxisRaw("Mouse Y") * swayRotAmount;
        mouseX = Mathf.Clamp(mouseX, -maxRotAmount, maxRotAmount);
        mouseY = Mathf.Clamp(mouseY, -maxRotAmount, maxRotAmount);

        Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRotation = rotationX * rotationY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smoothRotAmount * Time.deltaTime);
    }
}
