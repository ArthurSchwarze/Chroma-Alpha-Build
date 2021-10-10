using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ShowColor : MonoBehaviour
{
    private int ColourNumber = 5;

    public List<Color> colourList = new List<Color>();

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        colourList.Add(Color.green);
        colourList.Add(Color.blue);
        colourList.Add(Color.yellow);
        colourList.Add(Color.red);
        colourList.Add(Color.magenta);
        colourList.Add(Color.white);

        GetComponent<Image>().color = colourList[ColourNumber];

        GameObject arms = GameObject.Find("Arms");
        anim = arms.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo isReloading = anim.GetCurrentAnimatorStateInfo(0);
        //GetComponent<Image>().color = Color.green;

        ColourNumber = GetPressedNumber();

        if (ColourNumber != -1 && ColourNumber < 6 && !isReloading.IsName("Arms Reload"))
        {
            GetComponent<Image>().color = colourList[ColourNumber];
        }
    }

    public int GetPressedNumber()
    {
        for (int number = 0; number <= 9; number++)
        {
            if (Input.GetKeyDown(number.ToString()))
                return number - 1;
        }

        return -1;
    }
}
