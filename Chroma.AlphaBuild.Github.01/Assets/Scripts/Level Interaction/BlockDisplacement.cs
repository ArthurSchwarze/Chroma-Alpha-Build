using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDisplacement : MonoBehaviour
{
    public GameObject[] pathNodes;
    public int currentNode = 0;
    public int[] waitNode;

    public bool mooving = false;
    public bool moovesCircle = false;
    public bool wayBack = false;

    private float difference;

    public int speed = 1;
    public int waitTime = 1;

    private Vector3 movementVector;

    // Start is called before the first frame update
    void Start()
    {
        /*if (pathNodes != null)
        {
            transform.position = pathNodes[0].transform.position;
            
            if (pathNodes.Length != 1)
            {
                movementVector = CreateSizedVector(pathNodes[1].transform.position - transform.position);
                currentNode = 1;
            }
        }
        else
        {
            mooving = false;
        }*/

        StartCoroutine(movementWait());
    }

    // Update is called once per frame
    void Update()
    {
        if (mooving)
        {
            if (movementVector != Vector3.zero)
            {
                CheckNode(); 
            }
            transform.position += movementVector * Time.deltaTime;
        }
        else
        {

        }
    }


    private void CheckNode()
    {
        difference = (pathNodes[currentNode].transform.position - transform.position).sqrMagnitude - (movementVector * Time.deltaTime).sqrMagnitude;

        if (difference < 0)
        {
            StartCoroutine(movementWait());
        }
    }

    private Vector3 CreateSizedVector(Vector3 vector)
    {
        var Coordinates = new List<float> { Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z) };
        float maxValue = Mathf.Max(Coordinates.ToArray());

        return (vector * speed / Mathf.Abs(maxValue));
    }

    IEnumerator movementWait()
    {
        transform.position = pathNodes[currentNode].transform.position;
        movementVector = Vector3.zero;
        
        foreach (int element in waitNode)
        {
            if (element == currentNode)
            {
                yield return new WaitForSecondsRealtime(waitTime);
            }
        }

        if (currentNode == 0)
        {
            wayBack = false;
        }  
        else if (currentNode + 1 == pathNodes.Length)
        {
            if (moovesCircle)
            {
                wayBack = true;
            }
            else
            {
                currentNode = -1;
            }
            
        }
        
        if (wayBack)
        {
            currentNode--;
        }   
        else
        {
            currentNode++;
        }
        movementVector = CreateSizedVector(pathNodes[currentNode].transform.position - transform.position);
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("collision.gameObject.layer");
    }
}
