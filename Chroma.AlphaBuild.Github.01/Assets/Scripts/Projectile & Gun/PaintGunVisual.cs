using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintGunVisual : MonoBehaviour
{
    public float fireRate = 5f;

    public ParticleSystem gunSplatterVFX;

    private float nextTimeToFire = 0f;

    [SerializeField] private Material gunSplatterMaterial;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gunSplatterMaterial.color = new Color32(255, 255, 255, 255);
        GameObject arms = GameObject.Find("Arms");
        anim = arms.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo isReloading = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetKeyDown(KeyCode.Alpha1) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC1", .62f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC2", .62f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC3", .62f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC4", .62f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC5", .62f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6) && !isReloading.IsName("Arms Reload"))
        {
            Invoke("changeC6", .62f);
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && !isReloading.IsName("Arms Reload"))
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            gunSplatterVFX.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            gunSplatterVFX.Stop();
        }
    }

    private void changeC1()
    {
        gunSplatterMaterial.color = new Color32(69, 178, 51, 255);
    }
    private void changeC2()
    {
        gunSplatterMaterial.color = new Color32(70, 51, 178, 255);
    }
    private void changeC3()
    {
        gunSplatterMaterial.color = new Color32(243, 237, 63, 255);
    }
    private void changeC4()
    {
        gunSplatterMaterial.color = new Color32(204, 20, 20, 255);
    }
    private void changeC5()
    {
        gunSplatterMaterial.color = new Color32(255, 0, 213, 255);
    }
    private void changeC6()
    {
        gunSplatterMaterial.color = new Color32(255, 255, 255, 255);
    }
}
