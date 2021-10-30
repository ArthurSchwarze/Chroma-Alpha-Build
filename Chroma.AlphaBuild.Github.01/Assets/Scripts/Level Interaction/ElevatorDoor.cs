using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public float speed;
    public Vector3 targetPos;

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, speed * Time.deltaTime);
    }
}
