using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{

  public  int fallenCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Enemy"))
        {
            fallenCount++;
            Destroy(other.gameObject);

            if (fallenCount >= EnemySpawner.totalSpawns)
            {
                GumLevelUI.instance.Dropped();
                GumLevelUI.instance.Complete();
            }
        }
    }
}
