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

	//public List<Material> colourList = new List<Material>();

	public Material[] values = new Material[5];

	private GameObject character;
	private GameObject colouredObject;

	private int ColourNumber = 0;

	private ColorActivation colAct;
	private PauseMenu mouse;
	private EquipWeapon doesAction;
	private Animator anim;

	[SerializeField] PhysicMaterial bounceMaterial;
	[SerializeField] PhysicMaterial speedBoostMaterial;
	[HideInInspector] public bool yellowOneTime;

	// Start is called before the first frame update
	void Start()
	{
		mainCamera = GameObject.FindWithTag("MainCamera");

		character = this.gameObject;

		colAct = gameObject.GetComponent<ColorActivation>();
		mouse = GameObject.Find("Pause Menu Canvas").GetComponent<PauseMenu>();
		doesAction = gameObject.GetComponent<EquipWeapon>();
		anim = GameObject.Find("Arms").GetComponent<Animator>();

		//colourList.Add(MaterialWhite);
		//colourList.Add(MaterialRed);
		//colourList.Add(MaterialBlue);
		//colourList.Add(MaterialGreen);
		//colourList.Add(MaterialYellow);
		//colourList.Add(MaterialPurple);
	}

	// Update is called once per frame
	void Update()
	{
		AnimatorStateInfo isReloading = anim.GetCurrentAnimatorStateInfo(0);

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
		if (doesAction.action == false && !mouse.gameIsPaused)
        {
			if (number >= 0 && number < 6 && !isReloading.IsName("Arms Reload"))
			{
				ColourNumber = number;
			}
		}
	}

	public void MoveColour(GameObject o)
	{
		Collider c = o.GetComponent<Collider>();
		Rigidbody r = o.GetComponent<Rigidbody>();
		CubeCollDetect d = o.GetComponent<CubeCollDetect>();

		if (o.GetComponent<MeshRenderer>().material.name == MaterialColour[ColourNumber].name + " (Instance)")
		{
			return;
        }
		
		o.GetComponent<MeshRenderer>().material = MaterialColour[ColourNumber];
		o.GetComponent<GravityGameObject>().ColorChangeGravity();

		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "Cube";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);

		if (o.GetComponent<ConnectObjects>() != null)
        {
			o.GetComponent<ConnectObjects>().DisableScript();
        }


		if (ColourNumber == 4) // Colour: Green (Bounce) active 
		{
			c.material = bounceMaterial;
			r.AddForce(d.normal * 10f, ForceMode.Impulse);
		}

		if (ColourNumber == 1) // Colour: Blue (No Collision) active
		{
			o.tag = "ignoreCollision";
			Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>());
			c.material = null;
		}

		if (ColourNumber == 3) // Colour: Yellow (Speedboost) active
		{
			c.material = speedBoostMaterial;
			yellowOneTime = true;
		}

		if (ColourNumber == 2)  // Colour: Red (Gravity Change) active
		{
			o.GetComponent<GravityGameObject>().gravityModifier = -1;
			c.material = null;
		}

		if (ColourNumber == 5) // Colour: Purple (Connect Objects) active
		{
			o.AddComponent<ConnectObjects>();
			c.material = null;
		}

		if (ColourNumber == 0) // Colour: White (Default) always active
		{
			c.material = null;
		}
	}
	/*
	int GetPressedNumber()
	{
		for (int number = 0; number <= 9; number++)
		{
			if (Input.GetKeyDown(number.ToString()))
				return number -1;
		}

		return -1;
	}
	*/
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
