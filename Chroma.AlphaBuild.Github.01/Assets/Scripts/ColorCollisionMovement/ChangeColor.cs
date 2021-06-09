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

	public List<Material> colourList = new List<Material>();

	public Material[] values = new Material[5];

	private GameObject character;
	private GameObject colouredObject;

	private int ColourNumber = 3;


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


		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			ColourNumber = 3;
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			ColourNumber = 2;
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			ColourNumber = 4;	
		}

		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			ColourNumber = 1;
		}

		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			ColourNumber = 0;
		}
	}

	public void MoveColour(GameObject o)
	{
		o.GetComponent<MeshRenderer>().material = colourList[ColourNumber];
		o.GetComponent<GravityGameObject>().ColorChangeGravity(); 

		if (ColourNumber == 0)
		{
			MoveColourWhite(o);
		}

		if (ColourNumber == 1)
		{
			MoveColourRed(o);
		}

		if (ColourNumber == 2)
		{
			MoveColourBlue(o);
		}

		if (ColourNumber == 3)
		{
			MoveColourGreen(o);
		}
	}

	void MoveColourRed(GameObject o)
	{
		o.GetComponent<GravityGameObject>().gravityModifier = -1;
		o.tag = "Untagged";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);
	}

	void MoveColourWhite(GameObject o)
	{
		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "Untagged";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);
	}

	void MoveColourBlue(GameObject o)
	{
		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "ignoreCollision";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>());
	}

	void MoveColourGreen(GameObject o) 
	{
		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "Untagged";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);
	}
}
