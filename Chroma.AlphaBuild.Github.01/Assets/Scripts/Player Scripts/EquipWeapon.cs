using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    GameObject mainCamera;
    GameObject equipTrigger;
    GameObject equipTrigger2;
    GameObject unequipTrigger;

    GameObject equipGun;
    GameObject unequipGun;

    EquipTrigger isEquipped;
    EquipTrigger isEquipped2;
    EquipTrigger isUnequipped;

    public LayerMask equip;
    public LayerMask unequip;

    [HideInInspector]
    public bool action;

    private Animator anim;

    private GameObject pauseCanvas;
    private PauseMenu mouse;

    private GameObject crosshairNormal;

    private PickAndDrop drop;
    public ParticleSystem electroMagnet;
    private AudioSource emSound;

    // Start is called before the first frame update
    void Start()
    {
        crosshairNormal = GameObject.Find("CrosshairNormal");

        pauseCanvas = GameObject.Find("Pause Menu Canvas");
        mouse = pauseCanvas.GetComponent<PauseMenu>();

        // the first Animator Component in Children, here Arms
        anim = GetComponentInChildren<Animator>();

        mainCamera = GameObject.FindWithTag("MainCamera");

        equipTrigger = GameObject.Find("EquipTrigger");
        isEquipped = equipTrigger.GetComponent<EquipTrigger>();
        equipTrigger2 = GameObject.Find("EquipTrigger2");
        isEquipped2 = equipTrigger2.GetComponent<EquipTrigger>();

        unequipTrigger = GameObject.Find("UnequipTrigger");
        isUnequipped = unequipTrigger.GetComponent<EquipTrigger>();

        equipGun = GameObject.Find("EquipGun");
        unequipGun = GameObject.Find("UnequipGun");
        unequipGun.SetActive(false);

        drop = gameObject.GetComponent<PickAndDrop>();
        emSound = electroMagnet.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (Input.GetMouseButton(1) && !mouse.gameIsPaused)
        {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 7f, equip))
            {
                Destroy(hit.collider.GetComponent<Interactable>());
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Object");

                crosshairNormal.SetActive(false);

                isEquipped.equipped = true;
                isEquipped2.equipped = true;
                isUnequipped.equipped = true;

                anim.CrossFadeInFixedTime("PaintGun Equip", .01f);

                Destroy(equipGun);
            }

            if (Physics.Raycast(ray, out hit, 7f, unequip))
            {
                Destroy(hit.collider.GetComponent<Interactable>());
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Object");

                DropObject();

                anim.CrossFadeInFixedTime("PaintGun Unequip", .01f);

                Invoke("deactivateMyHands", .7f);

                Invoke("activateGunObject", .8f);
            }
        }

        if (info.IsName("PaintGun Equip"))
        {
            action = true;
        }

        if (info.IsName("PaintGun Unequip"))
        {
            action = true;
        }

        else
        {
            Invoke("Action", 1f);
        }
    }

    void DropObject()
    {
        if (drop.carrying)
        {
            emSound.Stop();
            electroMagnet.Stop();
            drop.dropObject();
        }
    }

    private void activateGunObject()
    {
        unequipGun.SetActive(true);
    }

    private void deactivateMyHands()
    {
        isEquipped.equipped = false;
        isEquipped2.equipped = false;
        isUnequipped.equipped = false;
        crosshairNormal.SetActive(true);
    }

    private void Action()
    {
        action = false;
    }

    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

        if (info.IsName("PaintGun Equip"))
        {
            anim.SetBool("Equip", false);
        }

        if (info.IsName("PaintGun Unequip"))
        {
            anim.SetBool("Unequip", false);
        }
    }
}
