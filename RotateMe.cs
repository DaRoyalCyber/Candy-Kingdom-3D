using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMe : MonoBehaviour
{

    public Vector3 dir;

    public float speed;

    private void Update()
    {
        
        transform.Rotate(dir * speed *  Time.deltaTime);
    }

}
