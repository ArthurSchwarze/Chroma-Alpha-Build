using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooNear : MonoBehaviour
{
    public Transform spawnDirection;
    public LayerMask groundMask;
    public LayerMask objectMask;

    public float range = 2f;
    public bool tooNear;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnDirection.transform.position, spawnDirection.transform.forward, out hit, range, groundMask))
        {
            tooNear = true;
        }

        if (Physics.Raycast(spawnDirection.transform.position, spawnDirection.transform.forward, out hit, range, objectMask))
        {
            tooNear = true;
        }
    }
}
