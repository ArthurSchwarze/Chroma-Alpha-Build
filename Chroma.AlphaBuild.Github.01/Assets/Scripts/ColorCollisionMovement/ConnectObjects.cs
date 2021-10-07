using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObjects : MonoBehaviour
{
    public List<GameObject> collisionObjects = new List<GameObject>();

    public int Placement;
    public GameObject objectLayer;

    private ConnectObjects[] allObjects;
    private Object original;

    private GameObject clonedHitbox;


    // Start is called before the first frame update
    void Start()
    {
        original = GameObject.Find("BlockCollider");
        allObjects = Object.FindObjectsOfType<ConnectObjects>();
        Placement = allObjects.Length;
        objectLayer = transform.gameObject;
        
        Debug.Log(Placement);
        
        if (Placement == 1) 
        {
            objectLayer.layer = LayerMask.NameToLayer("1Connect");
        }

        if (Placement == 2) 
        {
            objectLayer.layer = LayerMask.NameToLayer("2Connect");
            NewConnect();
        }

        clonedHitbox = (GameObject)Instantiate(original, transform.position, Quaternion.identity);
        clonedHitbox.transform.parent = transform;
        clonedHitbox.AddComponent<ChildCollision>();

        
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

                if (Placement == 1) 
                {
                    objectLayer.layer = LayerMask.NameToLayer("1Connect");
                }

                if (Placement == 2)
                {
                    objectLayer.layer = LayerMask.NameToLayer("2Connect");
                    NewConnect();
                }

                Debug.Log(Placement);
            }
                //Debug.Log(allObjects[number].Placement + Placement);
        }
    }

    public void DisableScript()
    {
        Debug.Log("Disabled");
        
        Destroy(clonedHitbox);
        Destroy(GetComponent<ConnectObjects>());

        objectLayer.layer = LayerMask.NameToLayer("Ground");
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

    public void NewConnect() 
    {
        Debug.Log("StartNewConnection");
    }

    public void CheckConnect() 
    { 
        
    }

    //Is called when Child enters a collision
    public void OnChildCollisionEnter(Collider collider) 
    {
        GameObject game = collider.gameObject;
        //Debug.Log("enter " + game);

        collisionObjects.Add(game);

        return;
    }
   
    //Is called when Child stays in collision
    public void OnChildCollisionStay(Collider collider) 
    {
        GameObject game = collider.gameObject;

        if (!collisionObjects.Contains(game)) 
        {
            collisionObjects.Add(game);
        }
    }

    //Is called when Child exits a collision
    public void OnChildCollisionExit(Collider collider) 
    {
        GameObject game = collider.gameObject;
        //Debug.Log("exit " + game);

        collisionObjects.Remove(game);
    }
}
