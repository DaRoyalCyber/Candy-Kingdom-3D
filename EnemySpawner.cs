using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{

    public  int totalEnemys;
    public static int totalSpawns;

    public GameObject enemyPre;

    public Transform[] spawnPoints;

    public float spawnDelay = 1f;

    bool doSpawn;

    // uI logic helper 

     UITutorial tutorialScript;

    public Transform dropOff;

    public bool anyToDrop;

    int spawned = 0;

    public static int enemiesDefeated = 0;

    private void Start()
    {
        tutorialScript = FindObjectOfType<UITutorial>();
        totalSpawns = totalEnemys;
        EnemySpawner.enemiesDefeated = 0;
        EnemySpawner.totalSpawns = totalEnemys;
    }
    private void Update()
    {
        if (tutorialScript != null && tutorialScript.instructionText.gameObject.activeSelf && !doSpawn)
        {
            doSpawn= true;
            StartCoroutine(Spawner());
            if (SceneManager.GetActiveScene().name == "bridgeLevel")
            {

                   BridgeAudio.instance.PlayEnemySpawn();
            }
            else if (SceneManager.GetActiveScene().name == "SpinningLevel")
            {
                BridgeAudio.instance.PlayEnemySpawn();
            }

         
        }
    }
    IEnumerator Spawner()
    {
        while (spawned < totalEnemys)
        {
          Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

           GameObject enemy =   Instantiate(enemyPre, spawnPoint.position, spawnPoint.rotation);
            enemy.GetComponent<Enemies>().dropPoint = dropOff;
             
            spawned++;
          
            yield return new WaitForSeconds(spawnDelay);
        }
        doSpawn = false;
        }


    public static void RegisterEnemyDeath()
    {
        enemiesDefeated++;
        if (enemiesDefeated >= totalSpawns)
        {
         
            LevelCompleteUI.instance.CheckComplete();
        }
    }

}
