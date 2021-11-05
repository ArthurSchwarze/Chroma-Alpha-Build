using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeAct : MonoBehaviour
{
	GameObject character;
	private int ColourNumber = 0;

	[Header("Materials")]
	[Tooltip("Color for the Cubes")]
	[SerializeField] Material[] MaterialColour;

	[Space]

	[Header("Which Color should already be activated [ONLY 1]")] // other than white of course, which is already default
	[Tooltip("Cube will get this Color at start, white is default!")]
	public bool blue;
	[Tooltip("Cube will get this Color at start, white is default!")]
	public bool red;
	[Tooltip("Cube will get this Color at start, white is default!")]
	public bool yelllow;
	[Tooltip("Cube will get this Color at start, white is default!")]
	public bool green;
	[Tooltip("Cube will get this Color at start, white is default!")]
	public bool magenta;

	[Space]

	[Header("Physic Materials")]
	[Tooltip("Behavior for Green and Yellow Cube")]
	[SerializeField] PhysicMaterial bounceMaterial;
	[SerializeField] PhysicMaterial speedBoostMaterial;

	// Start is called before the first frame update
	void Start()
    {
		character = GameObject.Find("FirstPersonPlayer");
		MoveColour(this.gameObject);
    }

	public void MoveColour(GameObject o)
	{
		Collider c = o.GetComponent<Collider>();

		o.GetComponent<GravityGameObject>().ColorChangeGravity();

		o.GetComponent<GravityGameObject>().gravityModifier = 1;
		o.tag = "Cube";
		Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>(), false);

		if (o.GetComponent<ConnectObjects>() != null)
		{
			o.GetComponent<ConnectObjects>().DisableScript();
		}


		if (green) // Colour: Green (Bounce) active 
		{
			c.material = bounceMaterial;
			ColourNumber = 4;
		}

		if (blue) // Colour: Blue (No Collision) active
		{
			o.tag = "ignoreCollision";
			Physics.IgnoreCollision(character.GetComponent<Collider>(), o.GetComponent<Collider>());
			c.material = null;
			ColourNumber = 1;
		}

		if (yelllow) // Colour: Yellow (Speedboost) active
		{
			c.material = speedBoostMaterial;
			ColourNumber = 3;
		}

		if (red)  // Colour: Red (Gravity Change) active
		{
			o.GetComponent<GravityGameObject>().gravityModifier = -1;
			c.material = null;
			ColourNumber = 2;
		}

		if (magenta) // Colour: Purple (Connect Objects) active
		{
			o.AddComponent<ConnectObjects>();
			c.material = null;
			ColourNumber = 5;
		}

		if (o.GetComponent<MeshRenderer>().material.name == MaterialColour[ColourNumber].name + " (Instance)")
		{
			return;
		}

		o.GetComponent<MeshRenderer>().material = MaterialColour[ColourNumber];
	}
}
