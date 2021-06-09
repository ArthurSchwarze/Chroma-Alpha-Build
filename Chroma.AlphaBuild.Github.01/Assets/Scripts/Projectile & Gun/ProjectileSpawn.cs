using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public float fireRate = 5f;

    public GameObject[] blobProjectiles;
    public GameObject ghostProjectile;

    private float nextTimeToFire = 0f;

    private int number = 0;

    // Update is called once per frame
    void Update()
    {
        GameObject paintGun = GameObject.Find("PlaceholderGun");
        TooNear obstacleCheck = paintGun.GetComponent<TooNear>();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            number = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            number = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            number = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            number = 3;
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && obstacleCheck.tooNear == false)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Instantiate(blobProjectiles[number], transform.position, transform.rotation);
            Instantiate(ghostProjectile, transform.position, transform.rotation);
        }

        else
        {
            obstacleCheck.tooNear = false;
        }
    }
}
