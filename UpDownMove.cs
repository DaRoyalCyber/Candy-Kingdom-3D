using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{

    public float flyPower = 0.2f;
    public float flySpeed = 2f;

    Vector3 startPOs;
    float offset;

    private void Start()
    {
        startPOs = transform.position;
        offset = Random.Range(0f, 100f);

    }
    private void Update()
    {
      

        float upDown = Mathf.Sin((Time.time + offset) * flySpeed) * flyPower;
       
        transform.position = new Vector3(startPOs.x,startPOs.y + upDown,startPOs.z);

    }

}
