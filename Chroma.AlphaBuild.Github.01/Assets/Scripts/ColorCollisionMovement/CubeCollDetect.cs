using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollDetect : MonoBehaviour
{
    [HideInInspector] public Vector3 normal;

    private void OnCollisionStay(Collision collision)
    {
        normal = collision.contacts[0].normal;
    }
}
