using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostProjectile : MonoBehaviour
{
    public float damage = 10f;
    public float impactForce = 35f;

    public float speed = 20f;
    public int predictionStepsPerFrame = 6;
    public Vector3 bulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        bulletVelocity = this.transform.forward * speed;
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
            if (Physics.Raycast(ray, out hit, (point2 - point1).magnitude))
            {
                speed = 0f;

                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                Destroy(gameObject);
            }

            point1 = point2;
        }

        this.transform.position = point1;
    }
}
