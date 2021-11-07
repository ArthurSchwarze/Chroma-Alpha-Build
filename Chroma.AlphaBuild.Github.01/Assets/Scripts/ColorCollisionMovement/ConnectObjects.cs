using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObjects : MonoBehaviour
{
    public List<GameObject> collisionObjects = new List<GameObject>();

    public int Placement;
    public GameObject thisGameObject;

    private ConnectObjects[] allObjects;
    private Object original;

    private GameObject clonedHitbox;

    private Vector3 difference12;
    public ConnectObjects object1;
    public GameObject object2;
    private bool inConnection;


    // Start is called before the first frame update
    void Start()
    {
        original = GameObject.Find("BlockCollider");
        allObjects = Object.FindObjectsOfType<ConnectObjects>();
        Placement = allObjects.Length;
        thisGameObject = transform.gameObject;
        
        //Debug.Log(Placement);

        clonedHitbox = (GameObject)Instantiate(original, transform.position, Quaternion.identity);
        clonedHitbox.transform.rotation = transform.rotation;
        clonedHitbox.transform.parent = transform;
        clonedHitbox.AddComponent<ChildCollision>();

        if (Placement == 1) 
        {
            thisGameObject.layer = LayerMask.NameToLayer("1Connect");
        }

        if (Placement == 2) 
        {
            thisGameObject.layer = LayerMask.NameToLayer("2Connect");
            NewConnect();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject nearObject in collisionObjects)
        {
            GameObject clone = GameObject.Find(Placement + "clone" + nearObject.name);
            if (clone != null)
            {
                clone.transform.position = nearObject.transform.position + difference12;
                clone.transform.rotation = nearObject.transform.rotation;

                if (clone.GetComponent<Rigidbody>() != null)
                {
                    clone.GetComponent<Rigidbody>().velocity = nearObject.GetComponent<Rigidbody>().velocity;
                }
            }
        }

        // -----------------------------------------------------------------------------------------------------
        
        allObjects = Object.FindObjectsOfType<ConnectObjects>();

        if (Placement != 1)
        {
            if (CheckFreePlacement(Placement)) 
            {
                Placement--;

                if (Placement == 1) 
                {
                    thisGameObject.layer = LayerMask.NameToLayer("1Connect");
                }

                if (Placement == 2)
                {
                    thisGameObject.layer = LayerMask.NameToLayer("2Connect");
                    NewConnect();
                }

                //Debug.Log(Placement);
            }
                //Debug.Log(allObjects[number].Placement + Placement);
        }

        if (Placement == 1)
        {
            if (object2 != null && object1 != null)
            {
                Vector3 difference = object2.transform.position - object1.transform.position;
                Vector3 differenceFlaw = (difference - difference12) / 2;

                if (difference != difference12)
                {
                    object1.transform.position += differenceFlaw;
                    object2.transform.position -= differenceFlaw;
                }
            }
        }

    }

    public void DisableScript()
    {
        if (Placement != 1 && Placement != 2) 
        {
            return;
        }
        
        

        //Debug.Log("Disabled");

        if (GameObject.Find("FirstPersonPlayer").GetComponent<PickAndDrop>().carriedObject == transform.gameObject) 
        {
            if (Placement == 1)
            {
                var connectedObject = object2;
                if (connectedObject != null)
                {
                    connectedObject.GetComponent<GravityGameObject>().temporaryBreak = false;
                    Rigidbody connectedRigidbody = connectedObject.GetComponent<Rigidbody>();
                    connectedRigidbody.velocity = Vector3.zero;
                    connectedRigidbody.angularVelocity = Vector3.zero;
                }
            }
            if (Placement == 2)
            {
                ConnectObjects connectedObject = object1;
                if (connectedObject != null)
                {
                    connectedObject.GetComponent<GravityGameObject>().temporaryBreak = false;
                    Rigidbody connectedRigidbody = connectedObject.GetComponent<Rigidbody>();
                    connectedRigidbody.velocity = Vector3.zero;
                    connectedRigidbody.angularVelocity = Vector3.zero;
                }
            }
        }

        foreach (ConnectObjects gameObject in allObjects)
        {
            if (gameObject.GetComponent<ConnectObjects>().Placement == 1)
            {
                gameObject.DestroyAllClones();
            }

            if (gameObject.GetComponent<ConnectObjects>().Placement == 2)
            {
                gameObject.DestroyAllClones();
            }
        }

        Destroy(clonedHitbox);
        Destroy(GetComponent<ConnectObjects>());

        thisGameObject.layer = LayerMask.NameToLayer("Object");
    }

    public void DestroyAllClones()
    {
        inConnection = false;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        foreach (GameObject gameObject in collisionObjects)
        {
            GameObject clone = GameObject.Find(Placement + "clone" + gameObject.name);
            if (clone != null)
            {
                Destroy(clone);
            }
        }



        object1 = null;
        object2 = null;
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

    //Start off the connection and measure Vector3 (difference) 
    public void NewConnect() 
    {
        transform.rotation = Quaternion.identity;
        object2 = thisGameObject;
        
        foreach (ConnectObjects gameObject in allObjects)
        {
            if (gameObject.GetComponent<ConnectObjects>().Placement == 1)
            {
                object1 = gameObject;
            }
        }
        
        //Debug.Log("StartNewConnection");
        difference12 = object1.transform.position - object2.transform.position;

        object1.CreateListClones(difference12, object1, object2);
        CreateListClones(difference12, object1, object2);
    }

    //Creates Clones of all objects in list
    public void CreateListClones(Vector3 vector3, ConnectObjects objectOne, GameObject objectTwo)
    {
        transform.rotation = Quaternion.identity;

        object1 = objectOne;
        object2 = objectTwo;
        
        inConnection = true;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation; 
        
        if (Placement == 1) 
        {
            difference12 = -1 * vector3;
        }

        foreach (GameObject game in collisionObjects) 
        {
            CreateClone(game, difference12);
        }
    }

    public void CreateClone(GameObject gameObject, Vector3 vector3)
    {
        GameObject parent = GameObject.Find("ClonedCollisionObjects");

        GameObject clone = Instantiate(gameObject);
        clone.transform.position = gameObject.transform.position + vector3;
        clone.transform.parent = parent.transform;
        clone = RemoveScripts(clone);

        if (Placement == 1)
        {
            clone.layer = LayerMask.NameToLayer("ConnectCollision2");
        }

        if (Placement == 2)
        {
            clone.layer = LayerMask.NameToLayer("ConnectCollision1");
        }

        clone.name = Placement + "clone" + gameObject.name;
    }


    public void DestroyObject(GameObject game)
    {
        Destroy(game);
    }

    private GameObject RemoveScripts(GameObject game)
    {
        var components = game.GetComponents<Component>();
        foreach (var t in components)
        {
            if (t is Transform || t is MeshFilter || t is MeshRenderer || t is BoxCollider || t is MeshCollider || t is Rigidbody)
                continue;
            Destroy(t);
        }


        return game;
    }

    //Is called when Child enters a collision
    public void OnChildCollisionEnter(Collider collider) 
    {
        GameObject game = collider.gameObject;
        //Debug.Log("enter " + game);

        collisionObjects.Add(game);

        if (inConnection)
        {
            CreateClone(game, difference12);
        }

        return;
    }
   
    //Is called when Child stays in collision
    public void OnChildCollisionStay(Collider collider) 
    {
        GameObject game = collider.gameObject;

        if (!collisionObjects.Contains(game)) 
        {
            collisionObjects.Add(game);
            if (inConnection)
            {
                CreateClone(game, difference12);
            }
        }

        GameObject clone = GameObject.Find(Placement + "clone" + game.name);
        if (clone != null)
        {
            clone.transform.position = game.transform.position + difference12;
            clone.transform.rotation = game.transform.rotation;

            if (clone.GetComponent<Rigidbody>() != null)
            {
                clone.GetComponent<Rigidbody>().velocity = game.GetComponent<Rigidbody>().velocity;
            }
        }
    }

    //Is called when Child exits a collision
    public void OnChildCollisionExit(Collider collider) 
    {
        GameObject game = collider.gameObject;
        //Debug.Log("exit " + game);

        collisionObjects.Remove(game);

        GameObject clone = GameObject.Find(Placement + "clone" + game.name);
        if (clone != null)
        {
            Destroy(clone);
        }
        else
        {
            Debug.Log("Missed: " + Placement + "clone" + game.name);
        }
    }
}
