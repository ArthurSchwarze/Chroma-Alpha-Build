using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGunVisual : MonoBehaviour
{
    public float fireRate = 5f;

    public ParticleSystem gunSplatterVFX;

    private float nextTimeToFire = 0f;

    [SerializeField] private Material gunSplatterMaterial;

    // Start is called before the first frame update
    void Start()
    {
        gunSplatterMaterial.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunSplatterMaterial.color = new Color32(69, 178, 51, 255);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunSplatterMaterial.color = new Color32(70, 51, 178, 255);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunSplatterMaterial.color = new Color32(243, 237, 63, 255);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gunSplatterMaterial.color = new Color32(204, 20, 20, 255);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            gunSplatterMaterial.color = new Color32(255, 255, 255, 255);
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            gunSplatterVFX.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            gunSplatterVFX.Stop();
        }
    }
}
