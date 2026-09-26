using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LakeLogic : MonoBehaviour
{
    public GameObject enemyDrownPS;
    void OnTriggerEnter(Collider other)
    {
     if(other.gameObject.tag == "Enemy"){

            EnemySpawner.enemiesDefeated++;
            Instantiate(enemyDrownPS, other.transform.position, Quaternion.identity);
            BridgeAudio.instance.PlayEnemyDrown();
            Destroy(other.gameObject);
     }   
    } 
}
