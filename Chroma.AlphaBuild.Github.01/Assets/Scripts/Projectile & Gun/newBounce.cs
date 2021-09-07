using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newBounce : MonoBehaviour
{

    private Vector3 bounce = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        PlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        bounceTrigger.moveXYZ = bounce;
        bounce = Vector3.zero;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        PlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<PlayerMovement>();

        Rigidbody body = hit.collider.attachedRigidbody;

        var direction = Vector3.Reflect(bounceTrigger.moveXYZ.normalized, hit.normal);
        bounce = direction * Mathf.Max(hit.controller.velocity.magnitude, 13f);
    }
}
