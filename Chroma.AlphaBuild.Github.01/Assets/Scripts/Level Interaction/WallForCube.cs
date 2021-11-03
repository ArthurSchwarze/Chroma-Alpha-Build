using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallForCube : MonoBehaviour
{
    GameObject character;
    //EquipWeapon dropIt;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("FirstPersonPlayer");
        //dropIt = character.GetComponent<EquipWeapon>();

        Physics.IgnoreCollision(character.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("ignoreCollision"))
        {
            dropIt.DropObject();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("ignoreCollision"))
        {
            dropIt.DropObject();
        }
    }
    */
}
