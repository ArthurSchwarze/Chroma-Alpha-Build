using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractCrosshair : MonoBehaviour
{
    GameObject mainCamera;
    GameObject crosshair;
    GameObject crosshairNormal;

    public LayerMask ignoreLayer;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindWithTag("MainCamera");
        crosshair = GameObject.Find("Crosshair");
        crosshairNormal = GameObject.Find("CrosshairNormal");
    }

    // Update is called once per frame
    void Update()
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;

        Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 20f, ~ignoreLayer))
        {
            Interactable i = hit.collider.GetComponent<Interactable>();
            if(i != null)
            {
                crosshair.GetComponent<Image>().color = Color.green;
                crosshairNormal.GetComponent<Image>().color = Color.green;
            }

            else
            {
                crosshair.GetComponent<Image>().color = Color.white;
                crosshairNormal.GetComponent<Image>().color = Color.white;
            }
        }
    }
}
