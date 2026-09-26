using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UITutorial : MonoBehaviour
{
    public GameObject instructionPage;
    public TextMeshProUGUI instructionText;

    public Button ok;

    public string tutorial = "You Should do and do";

    // timer
   // public TextMeshProUGUI timeText;

  //  float timer = 0f;


    //action
    public Enemies enemyScript;
    //this did not work
    public Cannon cannonScript;
    public EnemySpawner spawnerScript;
    public TimerEffect timerEffect;

    private void Start()
    {
        instructionPage.SetActive(true);

        instructionText.text = tutorial;

        //stop all actions 
        enemyScript.enabled = false;
        cannonScript.enabled = false;
        spawnerScript.enabled = false;
        timerEffect.enabled = false;

    }
    private void Update()
    {
        /*timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);*/
    }
    public void CloseTutorial()
    {
        instructionPage.SetActive(false);
        enemyScript.enabled = true;
        cannonScript.enabled = true;
        spawnerScript.enabled = true;
        timerEffect.enabled = true;
        
    }

}
