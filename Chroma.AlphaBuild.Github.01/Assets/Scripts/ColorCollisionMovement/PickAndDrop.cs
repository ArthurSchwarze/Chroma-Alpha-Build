using UnityEngine;
using System.Collections;

public class PickAndDrop : MonoBehaviour
{
	GameObject mainCamera;
	public GameObject carriedObject;

	public bool carrying;

	public float distance;
	public float smooth;

	//private GameObject character;

	public bool stopXMovement;
	public int stopYMovement;
	public bool stopZMovement;

	public Vector3 actualMovement;

	public LayerMask ignoreLayer;

	public ParticleSystem electroMagnet;
	private AudioSource emSound;

	private GameObject pauseCanvas;
	private PauseMenu mouse;

	Collider c;
	PhysicMaterial phyMat;
	PhysicMaterial previousPhyMat;
	[HideInInspector] public float cubeSpeed = 12f;

	[HideInInspector] public bool isHolding;

	// Use this for initialization
	void Start()
	{
		pauseCanvas = GameObject.Find("Pause Menu Canvas");
		mouse = pauseCanvas.GetComponent<PauseMenu>();

		emSound = electroMagnet.GetComponent<AudioSource>();
		mainCamera = GameObject.FindWithTag("MainCamera");
		//character = GameObject.Find("FirstPersonPlayer");
	}

	// Update is called once per frame
	void Update()
	{
		if (carrying)
		{
			//carry(carriedObject);
			checkDrop();
			//rotateObject();
		}
		else
		{
			pickup();
		}
	}

    private void FixedUpdate()
    {
		if (carrying)
		{
			carry(carriedObject);
			//checkDrop();
			//rotateObject();
		}
	}

    void rotateObject()
	{
		carriedObject.transform.Rotate(5, 10, 15);
	}

	void carry(GameObject o)
	{
		Vector3 destination = Vector3.Lerp(o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth * 60);

		Vector3 newMove = destination - o.transform.position;
		actualMovement = newMove;

		o.GetComponent<Rigidbody>().velocity = newMove * cubeSpeed;

		if (o.GetComponent<ConnectObjects>() != null)
        {
			ConnectObjects connect = o.GetComponent<ConnectObjects>();
			if (connect.Placement == 1)
            {
				var connectedObject = connect.object2;
				if (connectedObject != null)
				{
					connectedObject.GetComponent<Rigidbody>().velocity = newMove * cubeSpeed;
					connectedObject.GetComponent<GravityGameObject>().temporaryBreak = true;
				}
			}
			if (connect.Placement == 2)
            {
				ConnectObjects connectedObject = connect.object1;
				if (connectedObject != null)
				{
					connectedObject.GetComponent<Rigidbody>().velocity = newMove * cubeSpeed;
					connectedObject.GetComponent<GravityGameObject>().temporaryBreak = true;
				}
			}
        }

		//o.transform.position += newMove;
		//o.transform.position = MoveBlock;

		o.transform.rotation = Quaternion.identity;

		if (((o.transform.position - (mainCamera.transform.position + mainCamera.transform.forward * distance)).magnitude) > 15f && !mouse.gameIsPaused)
        {
			c.material = previousPhyMat;
			cubeSpeed = 12f;

			emSound.Stop();
			electroMagnet.Stop();

			dropObject();

			isHolding = false;
		}
	}

	void pickup()
	{
		if (Input.GetKeyDown(KeyCode.E) && !mouse.gameIsPaused)
		{
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 12f, ~ignoreLayer))
			{
				Pickupable p = hit.collider.GetComponent<Pickupable>();
				if (p != null)
				{
					isHolding = true;

					cubeSpeed = 12;

					emSound.Play();
					electroMagnet.Play();

					carriedObject = p.gameObject;
					carriedObject.GetComponent<GravityGameObject>().temporaryBreak = true;
					carrying = true;
					//Physics.IgnoreCollision(character.GetComponent<Collider>(), carriedObject.GetComponent<Collider>(), false);

					Rigidbody r = carriedObject.gameObject.GetComponent<Rigidbody>();
					r.velocity = Vector3.zero;
					r.angularVelocity = Vector3.zero;

					c = carriedObject.GetComponent<Collider>();
					previousPhyMat = c.material;
					phyMat = new PhysicMaterial();
					phyMat.staticFriction = 0f;
					phyMat.dynamicFriction = 0f;
					phyMat.frictionCombine = PhysicMaterialCombine.Minimum;
					phyMat.bounciness = 0f;
					phyMat.bounceCombine = PhysicMaterialCombine.Minimum;
					c.material = phyMat;

					//p.GetComponent<Rigidbody>().isKinematic = true;
					//p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop()
	{
		if (Input.GetKeyDown(KeyCode.E) && !mouse.gameIsPaused)
		{
			c.material = previousPhyMat;
			cubeSpeed = 12f;

			emSound.Stop();
			electroMagnet.Stop();

			dropObject();

			isHolding = false;
		}
	}

	public void dropObject()
	{
		carrying = false;
		//carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		Rigidbody r = carriedObject.gameObject.GetComponent<Rigidbody>();
		carriedObject.GetComponent<GravityGameObject>().temporaryBreak = false;
		carriedObject.GetComponent<GravityGameObject>().ColorChangeGravity();

		if (carriedObject.GetComponent<ConnectObjects>() != null)
		{
			ConnectObjects connect = carriedObject.GetComponent<ConnectObjects>();
			if (connect.Placement == 1)
			{
				var connectedObject = connect.object2;
				if (connectedObject != null)
				{
					connectedObject.GetComponent<GravityGameObject>().temporaryBreak = false;
					Rigidbody connectedRigidbody = connectedObject.GetComponent<Rigidbody>();
					connectedRigidbody.velocity = Vector3.zero;
					connectedRigidbody.angularVelocity = Vector3.zero;
				}
			}
			if (connect.Placement == 2)
			{
				ConnectObjects connectedObject = connect.object1;
				if (connectedObject != null)
				{
					connectedObject.GetComponent<GravityGameObject>().temporaryBreak = false;
					Rigidbody connectedRigidbody = connectedObject.GetComponent<Rigidbody>();
					connectedRigidbody.velocity = Vector3.zero;
					connectedRigidbody.angularVelocity = Vector3.zero;
				}
			}
		}

		//GetComponent<PlayerMovement>().StopX = 0;
		//GetComponent<PlayerMovement>().StopZ = 0;
		//mainCamera.GetComponent<MouseLook>().LimitRotationY = 0;

		//Physics.IgnoreCollision(character.GetComponent<Collider>(), carriedObject.GetComponent<Collider>(), false);

		//r.useGravity = true;
		carriedObject = null;
		r.velocity = Vector3.zero;
		r.angularVelocity = Vector3.zero;
	}
}