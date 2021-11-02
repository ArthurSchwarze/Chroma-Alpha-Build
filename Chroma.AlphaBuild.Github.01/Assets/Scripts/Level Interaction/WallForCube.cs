using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallForCube : MonoBehaviour
{
    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("FirstPersonPlayer");

        Physics.IgnoreCollision(character.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
    }
}
