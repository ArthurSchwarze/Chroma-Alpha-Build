using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl5Platform : MonoBehaviour
{
    BlockDisplacement platform;

    private void Awake()
    {
        platform = GetComponent<BlockDisplacement>();
    }

    void Start()
    {
        Invoke("ActivateLater", 1f);
    }

    void ActivateLater()
    {
        platform.enabled = true;
    }
}
