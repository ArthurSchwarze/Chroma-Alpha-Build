using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorReset : MonoBehaviour
{
    private Collider character;

    [SerializeField] private Material colorMaterial;
    [SerializeField] private GameObject cube1;
    private MeshRenderer ccube1;
    private Collider cccube1;
    private GravityGameObject gcube1;

    [SerializeField] private GameObject cube2;
    private MeshRenderer ccube2;
    private Collider cccube2;
    private GravityGameObject gcube2;

    [SerializeField] private GameObject cube3;
    private MeshRenderer ccube3;
    private Collider cccube3;
    private GravityGameObject gcube3;

    [SerializeField] private GameObject cube4;
    private MeshRenderer ccube4;
    private Collider cccube4;
    private GravityGameObject gcube4;

    [SerializeField] private GameObject cube5;
    private MeshRenderer ccube5;
    private Collider cccube5;
    private GravityGameObject gcube5;

    [SerializeField] private GameObject cube6;
    private MeshRenderer ccube6;
    private Collider cccube6;
    private GravityGameObject gcube6;

    [SerializeField] private GameObject cube7;
    private MeshRenderer ccube7;
    private Collider cccube7;
    private GravityGameObject gcube7;

    [SerializeField] private GameObject cube8;
    private MeshRenderer ccube8;
    private Collider cccube8;
    private GravityGameObject gcube8;

    [SerializeField] private GameObject cube9;
    private MeshRenderer ccube9;
    private Collider cccube9;
    private GravityGameObject gcube9;

    [SerializeField] private GameObject cube10;
    private MeshRenderer ccube10;
    private Collider cccube10;
    private GravityGameObject gcube10;


    private void Awake()
    {
        character = GameObject.Find("FirstPersonPlayer").GetComponent<Collider>();

        if (cube1)
        {
            ccube1 = cube1.GetComponent<MeshRenderer>();
            cccube1 = cube1.GetComponent<Collider>();
            gcube1 = cube1.GetComponent<GravityGameObject>();
        }

        if (cube2)
        {
            ccube2 = cube2.GetComponent<MeshRenderer>();
            cccube2 = cube2.GetComponent<Collider>();
            gcube2 = cube2.GetComponent<GravityGameObject>();
        }

        if (cube3)
        {
            ccube3 = cube3.GetComponent<MeshRenderer>();
            cccube3 = cube3.GetComponent<Collider>();
            gcube3 = cube3.GetComponent<GravityGameObject>();
        }

        if (cube4)
        {
            ccube4 = cube4.GetComponent<MeshRenderer>();
            cccube4 = cube4.GetComponent<Collider>();
            gcube4 = cube4.GetComponent<GravityGameObject>();
        }

        if (cube5)
        {
            ccube5 = cube5.GetComponent<MeshRenderer>();
            cccube5 = cube5.GetComponent<Collider>();
            gcube5 = cube5.GetComponent<GravityGameObject>();
        }

        if (cube6)
        {
            ccube6 = cube6.GetComponent<MeshRenderer>();
            cccube6 = cube6.GetComponent<Collider>();
            gcube6 = cube6.GetComponent<GravityGameObject>();
        }

        if (cube7)
        {
            ccube7 = cube7.GetComponent<MeshRenderer>();
            cccube7 = cube7.GetComponent<Collider>();
            gcube7 = cube7.GetComponent<GravityGameObject>();
        }

        if (cube8)
        {
            ccube8 = cube8.GetComponent<MeshRenderer>();
            cccube8 = cube8.GetComponent<Collider>();
            gcube8 = cube8.GetComponent<GravityGameObject>();
        }

        if (cube9)
        {
            ccube9 = cube9.GetComponent<MeshRenderer>();
            cccube9 = cube9.GetComponent<Collider>();
            gcube9 = cube9.GetComponent<GravityGameObject>();
        }

        if (cube10)
        {
            ccube10 = cube10.GetComponent<MeshRenderer>();
            cccube10 = cube10.GetComponent<Collider>();
            gcube10 = cube10.GetComponent<GravityGameObject>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            if (cube1)
            {
                ccube1.material = colorMaterial;
                cube1.tag = "Cube";
                gcube1.ColorChangeGravity();
                gcube1.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube1, false);
                cccube1.material = null;
                if (cube1.GetComponent<ConnectObjects>()) cube1.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube2)
            {
                ccube2.material = colorMaterial;
                cube2.tag = "Cube";
                gcube2.ColorChangeGravity();
                gcube2.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube2, false);
                cccube2.material = null;
                if (cube2.GetComponent<ConnectObjects>()) cube2.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube3)
            {
                ccube3.material = colorMaterial;
                cube3.tag = "Cube";
                gcube3.ColorChangeGravity();
                gcube3.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube3, false);
                cccube3.material = null;
                if (cube3.GetComponent<ConnectObjects>()) cube3.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube4)
            {
                ccube4.material = colorMaterial;
                cube4.tag = "Cube";
                gcube4.ColorChangeGravity();
                gcube4.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube4, false);
                cccube4.material = null;
                if (cube4.GetComponent<ConnectObjects>()) cube4.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube5)
            {
                ccube5.material = colorMaterial;
                cube5.tag = "Cube";
                gcube5.ColorChangeGravity();
                gcube5.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube5, false);
                cccube5.material = null;
                if (cube5.GetComponent<ConnectObjects>()) cube5.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube6)
            {
                ccube6.material = colorMaterial;
                cube6.tag = "Cube";
                gcube6.ColorChangeGravity();
                gcube6.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube6, false);
                cccube6.material = null;
                if (cube6.GetComponent<ConnectObjects>()) cube6.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube7)
            {
                ccube7.material = colorMaterial;
                cube7.tag = "Cube";
                gcube7.ColorChangeGravity();
                gcube7.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube7, false);
                cccube7.material = null;
                if (cube7.GetComponent<ConnectObjects>()) cube7.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube8)
            {
                ccube8.material = colorMaterial;
                cube8.tag = "Cube";
                gcube8.ColorChangeGravity();
                gcube8.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube8, false);
                cccube8.material = null;
                if (cube8.GetComponent<ConnectObjects>()) cube8.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube9)
            {
                ccube9.material = colorMaterial;
                cube9.tag = "Cube";
                gcube9.ColorChangeGravity();
                gcube9.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube9, false);
                cccube9.material = null;
                if (cube9.GetComponent<ConnectObjects>()) cube9.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube10)
            {
                ccube10.material = colorMaterial;
                cube10.tag = "Cube";
                gcube10.ColorChangeGravity();
                gcube10.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube10, false);
                cccube10.material = null;
                if (cube10.GetComponent<ConnectObjects>()) cube10.GetComponent<ConnectObjects>().DisableScript();
            }
        } 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerBody"))
        {
            if (cube1)
            {
                ccube1.material = colorMaterial;
                cube1.tag = "Cube";
                gcube1.ColorChangeGravity();
                gcube1.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube1, false);
                cccube1.material = null;
                if (cube1.GetComponent<ConnectObjects>()) cube1.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube2)
            {
                ccube2.material = colorMaterial;
                cube2.tag = "Cube";
                gcube2.ColorChangeGravity();
                gcube2.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube2, false);
                cccube2.material = null;
                if (cube2.GetComponent<ConnectObjects>()) cube2.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube3)
            {
                ccube3.material = colorMaterial;
                cube3.tag = "Cube";
                gcube3.ColorChangeGravity();
                gcube3.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube3, false);
                cccube3.material = null;
                if (cube3.GetComponent<ConnectObjects>()) cube3.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube4)
            {
                ccube4.material = colorMaterial;
                cube4.tag = "Cube";
                gcube4.ColorChangeGravity();
                gcube4.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube4, false);
                cccube4.material = null;
                if (cube4.GetComponent<ConnectObjects>()) cube4.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube5)
            {
                ccube5.material = colorMaterial;
                cube5.tag = "Cube";
                gcube5.ColorChangeGravity();
                gcube5.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube5, false);
                cccube5.material = null;
                if (cube5.GetComponent<ConnectObjects>()) cube5.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube6)
            {
                ccube6.material = colorMaterial;
                cube6.tag = "Cube";
                gcube6.ColorChangeGravity();
                gcube6.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube6, false);
                cccube6.material = null;
                if (cube6.GetComponent<ConnectObjects>()) cube6.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube7)
            {
                ccube7.material = colorMaterial;
                cube7.tag = "Cube";
                gcube7.ColorChangeGravity();
                gcube7.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube7, false);
                cccube7.material = null;
                if (cube7.GetComponent<ConnectObjects>()) cube7.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube8)
            {
                ccube8.material = colorMaterial;
                cube8.tag = "Cube";
                gcube8.ColorChangeGravity();
                gcube8.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube8, false);
                cccube8.material = null;
                if (cube8.GetComponent<ConnectObjects>()) cube8.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube9)
            {
                ccube9.material = colorMaterial;
                cube9.tag = "Cube";
                gcube9.ColorChangeGravity();
                gcube9.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube9, false);
                cccube9.material = null;
                if (cube9.GetComponent<ConnectObjects>()) cube9.GetComponent<ConnectObjects>().DisableScript();
            }

            if (cube10)
            {
                ccube10.material = colorMaterial;
                cube10.tag = "Cube";
                gcube10.ColorChangeGravity();
                gcube10.gravityModifier = 1;
                Physics.IgnoreCollision(character, cccube10, false);
                cccube10.material = null;
                if (cube10.GetComponent<ConnectObjects>()) cube10.GetComponent<ConnectObjects>().DisableScript();
            }
        }
    }
}
