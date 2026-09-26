using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumBullet : MonoBehaviour
{
    public float magneticArea = 10f;
    public float magnetForce = 10f;

    public GameObject psGumBullet;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    private void FixedUpdate()
    {

        Collider[] rubble = Physics.OverlapSphere(transform.position, magneticArea);

        foreach (Collider collider in rubble)
        {
            if (collider.tag == "Rubble")
            {

                Rigidbody rb = collider.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    Vector3 dir = (transform.position - rb.position).normalized * 1.5f;

                    rb.angularVelocity = Vector3.up * 10f;
                    rb.AddForce(dir * magnetForce * Time.fixedDeltaTime, ForceMode.Acceleration);

                    rb.useGravity = true;



                    float dis = Vector3.Distance(rb.position, transform.position);
                    if (dis < 1f)
                    {
                        {
                            rb.velocity = Vector3.zero;
                            rb.constraints = RigidbodyConstraints.FreezeAll;

                            Instantiate(psGumBullet, transform.position, Quaternion.identity);
                            rb.gameObject.tag = "Glued";
                        }
                    }
                    /*

                    if (Vector3.Distance(rb.position, transform.position) < 1f)
                    {

                        rb.velocity = Vector3.zero;
                        rb.constraints = RigidbodyConstraints.FreezeAll;

                        Instantiate(psGumBullet, transform.position, Quaternion.identity);
                        rb.gameObject.tag = "Glued";



                    }*/
                }
            }
        }
    }



    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Rubble")
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.constraints |= RigidbodyConstraints.FreezeAll;
                other.tag = "Glued";
            }
        }
    }
 
}
