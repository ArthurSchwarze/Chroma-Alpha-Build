using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractCrosshair : MonoBehaviour
{
    Camera mainCamera;
    Image crosshair;
    Image crosshairNormal;

    public LayerMask ignoreLayer;

    void Awake()
    {
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        crosshairNormal = GameObject.Find("CrosshairNormal").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f, ~ignoreLayer))
        {
            Interactable i = hit.collider.GetComponent<Interactable>();
            if(i != null)
            {
                crosshair.color = Color.green;
                crosshairNormal.color = Color.green;
            }

            else
            {
                crosshair.color = Color.white;
                crosshairNormal.color = Color.white;
            }
        }

        else
        {
            crosshair.color = Color.white;
            crosshairNormal.color = Color.white;
        }
    }
}
