using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPAth : MonoBehaviour
{
   

    public Transform[] pathPoints;
 

    public float GetDistanceToPathStart(Vector3 position)
    {
        return Vector3.Distance(position, pathPoints[0].position);
    }
}
