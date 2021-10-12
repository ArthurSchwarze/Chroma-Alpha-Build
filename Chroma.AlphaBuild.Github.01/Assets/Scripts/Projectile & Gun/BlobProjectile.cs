using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobProjectile : MonoBehaviour
{
    public LayerMask groundMask;
    //public LayerMask objectMask;

    public GameObject collisionSplashVFX;
    public GameObject sprinkleVFX;
    public GameObject splatterDecal;

    private GameObject character;

    public float speed = 20f;
    public int predictionStepsPerFrame = 6;
    public Vector3 bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        groundMask = LayerMask.GetMask("Ground", "Object", "1Connect", "2Connect");

        bulletVelocity = this.transform.forward * speed;

        character = GameObject.Find("FirstPersonPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 point1 = this.transform.position;
        float stepSize = 1f / predictionStepsPerFrame;
        for (float step = 0f; step < 1f; step += stepSize)
        {
            bulletVelocity += Physics.gravity * stepSize * Time.deltaTime;
            Vector3 point2 = point1 + bulletVelocity * stepSize * Time.deltaTime;

            Ray ray = new Ray(point1, point2 - point1);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, (point2 - point1).magnitude, groundMask))
            {

                NonStick p = hit.collider.GetComponent<NonStick>();
                if (p == null)
                {
                    speed = 0f;

                    GameObject impactGO = Instantiate(collisionSplashVFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 0.5f);
                    GameObject impact2GO = Instantiate(sprinkleVFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact2GO, 0.5f);
                    Instantiate(splatterDecal, hit.point + hit.normal * 0.01f, Quaternion.LookRotation(-hit.normal));

                    Destroy(gameObject);
                }
                else
                {
                    GameObject impactGO = Instantiate(collisionSplashVFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGO, 0.5f);
                    GameObject impact2GO = Instantiate(sprinkleVFX, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impact2GO, 0.5f);

                    Destroy(gameObject);

                    if (hit.collider.GetComponent<Colorable>())
                    {
                        character.GetComponent<ChangeColor>().MoveColour(hit.transform.gameObject);
                    }
                }
            }

            point1 = point2;
        }

        this.transform.position = point1;
    }
}
