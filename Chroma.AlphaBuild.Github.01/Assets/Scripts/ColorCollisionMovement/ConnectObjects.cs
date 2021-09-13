using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObjects : MonoBehaviour
{
    public int Placement;
    private ConnectObjects[] allObjects;

    // Start is called before the first frame update
    void Start()
    {
        allObjects = Object.FindObjectsOfType<ConnectObjects>();
        Placement = allObjects.Length;
        Debug.Log(Placement);
    }

    // Update is called once per frame
    void Update()
    {
        allObjects = Object.FindObjectsOfType<ConnectObjects>();

        if (Placement != 1)
        {
            if (CheckFreePlacement(Placement)) 
            {
                Placement--;
                Debug.Log(Placement);
            }
                //Debug.Log(allObjects[number].Placement + Placement);
        }
    }

    private void OnDisable()
    {
        Debug.Log("Disabled");
    }

    private bool CheckFreePlacement(int place) 
    {
        for (int number = 0; number < allObjects.Length; number++) 
        { 
            if (allObjects[number].Placement + 1 == place) 
            {
                return false;
            }
        }
        return true;
    }
}
