using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoor : MonoBehaviour
{
    public float speed, speed2;
    public Vector3 targetPos, targetPos2;
    private bool start = true, finished;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, speed * Time.deltaTime);
            if (this.transform.localPosition == targetPos)
            {
                finished = true;
            }
        }

        if (finished)
        {
            start = false;
            Invoke("SecondDoorMove", 3f);
        }
    }

    void SecondDoorMove()
    {
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos2, speed2 * Time.deltaTime);
    }
}
