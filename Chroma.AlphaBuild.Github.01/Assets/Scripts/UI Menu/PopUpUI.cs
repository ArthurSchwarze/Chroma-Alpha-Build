using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpUI : MonoBehaviour
{
    public GameObject popUpUI;
    public float appearDelay;
    public float disappearDelay;
    private bool oneTime = true;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("PlayerBody"))
        {
            if (oneTime == true)
            {
                Invoke("Appear", appearDelay);
                oneTime = false;
            }
            Invoke("Disappear", disappearDelay);
        }
    }

    void Appear()
    {
        popUpUI.SetActive(true);
    }

    void Disappear()
    {
        popUpUI.SetActive(false);
        Destroy(this.gameObject);
    }
}
