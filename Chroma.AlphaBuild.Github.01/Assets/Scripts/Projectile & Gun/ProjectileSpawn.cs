using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public float fireRate = 5f;

    public GameObject[] blobProjectiles;
    public GameObject ghostProjectile;

    private float nextTimeToFire = 0f;

    private int number = 4;

    private Animator anim;
    private Animator anim2;
    private AudioSource reloadSource;
    public AudioClip[] reloadSFXs;
    private AudioClip reloadClip;
    private AudioSource shootSource;
    public AudioClip[] shootSFXs;
    private AudioClip shootClip;

    private EquipWeapon doesAction;

    private GameObject pauseCanvas;
    private PauseMenu mouse;

    private ColorActivation colAct;

    PickAndDrop pickAndDrop;

    private void Start()
    {
        pauseCanvas = GameObject.Find("Pause Menu Canvas");
        mouse = pauseCanvas.GetComponent<PauseMenu>();

        GameObject arms = GameObject.Find("Arms");
        anim = arms.GetComponent<Animator>();
        GameObject gun = GameObject.Find("PaintGun");
        anim2 = gun.GetComponent<Animator>();
        reloadSource = gun.GetComponent<AudioSource>();
        GameObject splatter = GameObject.Find("GunSplatter");
        shootSource = splatter.GetComponent<AudioSource>();

        GameObject FP = GameObject.Find("FirstPersonPlayer");
        doesAction = FP.GetComponent<EquipWeapon>();
        colAct = FP.GetComponent<ColorActivation>();
        pickAndDrop = FP.GetComponent<PickAndDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo isReloading = anim.GetCurrentAnimatorStateInfo(0);

        GameObject paintGun = GameObject.Find("PaintGun");
        TooNear obstacleCheck = paintGun.GetComponent<TooNear>();

        if (doesAction.action == false && !mouse.gameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.Alpha5) && !isReloading.IsName("Arms Reload") && colAct.green)
            {
                if (number != 0)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 0;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) && !isReloading.IsName("Arms Reload") && colAct.blue)
            {
                if (number != 1)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 1;
            }

            if (Input.GetKeyDown(KeyCode.Alpha4) && !isReloading.IsName("Arms Reload") && colAct.yellow)
            {
                if (number != 2)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 2;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) && !isReloading.IsName("Arms Reload") && colAct.red)
            {
                if (number != 3)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 3;
            }

            if (Input.GetKeyDown(KeyCode.Alpha6) && !isReloading.IsName("Arms Reload") && colAct.magenta)
            {
                if (number != 5)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 5;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1) && !isReloading.IsName("Arms Reload") && colAct.white)
            {
                if (number != 4)
                {
                    playReloadSound();
                    anim.CrossFadeInFixedTime("Arms Reload", .01f);
                    anim2.CrossFadeInFixedTime("Switch Reload", .01f);
                }
                number = 4;
            }

            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && obstacleCheck.tooNear == false && !isReloading.IsName("Arms Reload") && !pickAndDrop.isHolding)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Instantiate(blobProjectiles[number], transform.position, transform.rotation);
                Instantiate(ghostProjectile, transform.position, transform.rotation);

                playShootSound();

                anim.CrossFadeInFixedTime("Arms Shoot", .01f);
                anim2.CrossFadeInFixedTime("Barrel Recoil", .01f);
            }

            else
            {
                obstacleCheck.tooNear = false;
            }
        }
    }

    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("Arms Reload"))
        {
            anim.SetBool("Action", false);
        }

        AnimatorStateInfo info2 = anim.GetCurrentAnimatorStateInfo(1);

        if (info2.IsName("Arms Shoot"))
        {
            anim.SetBool("Action", false);
        }

        AnimatorStateInfo info3 = anim2.GetCurrentAnimatorStateInfo(1);

        if (info3.IsName("Switch Reload"))
        {
            anim2.SetBool("Action2", false);
        }

        AnimatorStateInfo info4 = anim2.GetCurrentAnimatorStateInfo(1);

        if (info4.IsName("Barrel Recoil"))
        {
            anim2.SetBool("Action2", false);
        }
    }

    private void playReloadSound()
    {
        int index = Random.Range(0, reloadSFXs.Length);
        reloadClip = reloadSFXs[index];
        reloadSource.clip = reloadClip;
        reloadSource.Play();
    }

    private void playShootSound()
    {
        int index = Random.Range(0, shootSFXs.Length);
        shootClip = shootSFXs[index];
        shootSource.clip = shootClip;
        shootSource.Play();
    }
}
