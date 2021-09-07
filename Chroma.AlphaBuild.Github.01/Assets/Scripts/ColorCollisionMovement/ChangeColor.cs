using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	GameObject mainCamera;

	public Material MaterialRed;
	public Material MaterialBlue;
	public Material MaterialGreen;
	public Material MaterialWhite;
	public Material MaterialYellow;
	public Material MaterialPurple;

	public Material[] MaterialColour;

	public List<Material> colourList = new List<Material>();

	public Material[] values = new Material[5];

	private GameObject character;
	private GameObject colouredObject;

	private int ColourNumber = 0;


	// Start is called before the first frame update
	void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera");

		character = GameObject.Find("FirstPersonPlayer");

		colourList.Add(MaterialWhite);
		colourList.Add(MaterialRed);
		colourList.Add(MaterialBlue);
		colourList.Add(MaterialGreen);
		colourList.Add(MaterialYellow);
		colourList.Add(MaterialPurple);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				Colorable p = hit.collider.GetComponent<Colorable>();
				if (p != null)
				{
					colouredObject = p.gameObject;
					MoveColour(colouredObject);
				}
			}
		}

		int number = GetPressedNumber();
		if (0 <= number && number <= 6) 
		{
			ColourNumber = number;
		}
	}

	public void MoveColour(GameObject o)
	{
		o.GetComponent<MeshRenderer>().material = MaterialColour[ColourNumber];
		o.GetComponent<GravityGameObject>().ColorChangeGravity();


		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "Untagged";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);


		if (ColourNumber == 0) // Colour: Green
		{
			//placeholder
		}

		if (ColourNumber == 1) // Colour: Blue
		{
			o.tag = "ignoreCollision";
			Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>());
		}

		if (ColourNumber == 2) // Colour: Yellow
		{
			//placeholder
		}

		if (ColourNumber == 3)  // Colour: Red
		{
			o.GetComponent<GravityGameObject>().gravityModifier = -1;
		}

		if (ColourNumber == 4) // Colour: Purple
		{
			//placeholder
		}

		if (ColourNumber == 5) // Colour: White
		{
			//placeholder
		}
	}

	public int GetPressedNumber()
	{
		for (int number = 0; number <= 9; number++)
		{
			if (Input.GetKeyDown(number.ToString()))
				return number -1;
		}

		return -1;
	}
}
