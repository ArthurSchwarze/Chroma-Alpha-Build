using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ShowColor : MonoBehaviour
{
    private int ColourNumber = 0;

    public List<Color> colourList = new List<Color>();

    private Animator anim;

    private EquipWeapon doesAction;

    private GameObject pauseCanvas;
    private PauseMenu mouse;

    private ColorActivation colAct;

    // Start is called before the first frame update
    void Start()
    {
        pauseCanvas = GameObject.Find("Pause Menu Canvas");
        mouse = pauseCanvas.GetComponent<PauseMenu>();

        colourList.Add(new Color32(255, 255, 255, 255));
        colourList.Add(new Color32(70, 51, 178, 255));
        colourList.Add(new Color32(204, 20, 20, 255));
        colourList.Add(new Color32(243, 237, 63, 255));
        colourList.Add(new Color32(69, 178, 51, 255));
        colourList.Add(new Color32(255, 0, 213, 255));

        GetComponent<Image>().color = colourList[ColourNumber];

        GameObject arms = GameObject.Find("Arms");
        anim = arms.GetComponent<Animator>();

        GameObject FP = GameObject.Find("FirstPersonPlayer");
        doesAction = FP.GetComponent<EquipWeapon>();
        colAct = FP.GetComponent<ColorActivation>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo isReloading = anim.GetCurrentAnimatorStateInfo(0);

        ColourNumber = GetPressedNumber();

        if (doesAction.action == false && !mouse.gameIsPaused)
        {
            if (ColourNumber >= 0 && ColourNumber < 6 && !isReloading.IsName("Arms Reload"))
            {
                GetComponent<Image>().color = colourList[ColourNumber];
            }
        }
    }

    int GetPressedNumber()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && colAct.white)
        {
            ColourNumber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && colAct.blue)
        {
            ColourNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && colAct.red)
        {
            ColourNumber = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4) && colAct.yellow)
        {
            ColourNumber = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5) && colAct.green)
        {
            ColourNumber = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6) && colAct.magenta)
        {
            ColourNumber = 5;
        }

        return ColourNumber;
    }
}
