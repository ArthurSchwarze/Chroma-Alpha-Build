using UnityEngine;

public class ChildCollision : MonoBehaviour
{
    public LayerMask ignoreLayer;
    public GameObject blockParent;

    private void Awake()
    {
        blockParent = transform.parent.gameObject;
        ignoreLayer = LayerMask.GetMask("1Connect", "2Connect", "ConnectCollision1", "ConnectCollision2",  "Ignore Raycast"); //"PhyBox",
    }

    private void OnTriggerEnter(Collider other)
    {
        if (blockParent != other.gameObject && CheckObject(other, ignoreLayer))
        {
            blockParent.GetComponent<ConnectObjects>().OnChildCollisionEnter(other);
        }
    }

    /*
     
    private void OnTriggerStay(Collider other)
    {
        if (blockParent != other.gameObject && CheckObject(other, ignoreLayer))
        {
            blockParent.GetComponent<ConnectObjects>().OnChildCollisionStay(other);
        }
    }

    */

    private void OnTriggerExit(Collider other)
    {
        if (blockParent != other.gameObject && CheckObject(other, ignoreLayer))
        {
            blockParent.GetComponent<ConnectObjects>().OnChildCollisionExit(other);
        }
    }

    private static bool CheckObject(Collider collider, LayerMask mask)
    {
        int layer = collider.gameObject.layer;

        string name = collider.gameObject.name;
        if (name == "Main Blob Projectile(Clone)" || name == "Blob 2 Variant Variant(Clone)" || name == "Blob 3 Variant Variant(Clone)" || name == "Blob 4 Variant Variant(Clone)" || name == "Blob 5 Variant Variant(Clone)" || name == "Blob 6 Variant Variant(Clone)" || name == "Ghost Blob(Clone)" || name == "Blob" || name == "FirstPersonPlayer") 
        {
            return false;
        }
        return mask != (mask | (1 << layer));
    }
}
