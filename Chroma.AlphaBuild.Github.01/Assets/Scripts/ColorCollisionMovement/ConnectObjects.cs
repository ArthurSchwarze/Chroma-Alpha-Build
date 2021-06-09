using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObjects : MonoBehaviour
{
    public int number;

    // Start is called before the first frame update
    void Start()
    {
        ConnectObjects[] allObjects = Object.FindObjectsOfType<ConnectObjects>();
        number = allObjects.Length;
        Debug.Log(number);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
