using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ShowColor : MonoBehaviour
{
    private int ColourNumber = 3;

    public List<Color> colourList = new List<Color>();

    // Start is called before the first frame update
    void Start()
    {
        colourList.Add(Color.white);
        colourList.Add(Color.red);
        colourList.Add(Color.blue);
        colourList.Add(Color.green);
        colourList.Add(Color.yellow);

        GetComponent<Image>().color = colourList[ColourNumber];
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Image>().color = Color.green;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ColourNumber = 3;
            GetComponent<Image>().color = colourList[ColourNumber];
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ColourNumber = 2;
            GetComponent<Image>().color = colourList[ColourNumber];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ColourNumber = 4;
            GetComponent<Image>().color = colourList[ColourNumber];
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ColourNumber = 1;
            GetComponent<Image>().color = colourList[ColourNumber];
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ColourNumber = 0;
            GetComponent<Image>().color = colourList[ColourNumber];
        }
    }
}
