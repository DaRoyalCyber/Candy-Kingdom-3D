using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumLevelHOUse : MonoBehaviour
{

    public float shakeduration = 0.5f;
    public float shakeAmount = 0.1f;

    Vector3 housePos;
    float currentshakeTime = 0f;

    int maxHits = 5;
    int numHits = 0;

    public float force = 10f;
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        housePos = transform.localPosition;

    }

    private void Update()
    {
        if (currentshakeTime > 0)
        {

            transform.localPosition = housePos + new Vector3(Random.Range(-2f, 2f),
                Random.Range(-2f, 2f), 0f) * shakeAmount;
            currentshakeTime -= Time.deltaTime;
        }
        else
        {
            // transform.localPosition = housePos;
        }
    }

    public void ShakeHouse()
    {
        if (numHits < maxHits)
        {


            numHits++;


            currentshakeTime = shakeduration;

            //UI to now how many shakes out of 3 ! 
        }
        if (numHits >= maxHits)
        {
            
          
            GumLevelUI.instance.DamagedHouse();
            

            Vector3 pushDir = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(pushDir * force, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Death")
        {
            GumLevelUI.instance.Fail();
        }
    }

}
