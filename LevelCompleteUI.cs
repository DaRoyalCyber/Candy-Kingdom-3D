using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleteUI : MonoBehaviour
{
    public static LevelCompleteUI instance;
    public GameObject uiWin;

    public Image[] stars;

    public Sprite goldStar;
    public Sprite noStar;

    public TextMeshProUGUI winText;

    int starsEarned = 0;

    bool levelComplete = false;
    bool candyPopped = false;
    bool houseSafe = true;

    public Button ok;
    public Button restartLevel;

    float timeLimit = 60f;
   float timeleft;

   bool isTimeUp = false;

    public string sceneTo;

    public int maxBullet = 5;
    public int bulletWarnning = 10;
   
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        timeleft = timeLimit;

        uiWin.SetActive(false);
    }

    private void Update()
    {
        if (!levelComplete)
        {
            timeleft -= Time.deltaTime;
            if (timeleft <= 0 && !levelComplete)
            {
                isTimeUp = true;
                timeleft = 0;
                CheckComplete();
            }
        }
    }

    public void CandyTriggerPressed()
    {
        candyPopped = true;
        CheckComplete();

    }

    public void HouseDamaged()
    {
        houseSafe = false;
        CheckComplete();
    }

    public void CheckComplete()
    {
        if (levelComplete) return;

        starsEarned = 0;

        int bulletsUsed = maxBullet - Cannon.instance.bulletCount;
        if (bulletsUsed <= bulletWarnning)

            starsEarned++;

        if (candyPopped) starsEarned++;

        if (houseSafe) starsEarned++;


        if (EnemySpawner.enemiesDefeated >= EnemySpawner.totalSpawns && (candyPopped || !houseSafe || bulletsUsed < bulletWarnning))
        {
            levelComplete = true;
            UpdateUI();


        }
    }

    public void Falled()
    {
        if(levelComplete) return;

        levelComplete = true;
        starsEarned = 0;
        UpdateUI();
    }
    void UpdateUI()
    {
        uiWin.SetActive(true);

        for (int i = 0; i < stars.Length; i++)
        {
            if (i < starsEarned) {

                stars[i].sprite = goldStar;
            }
            else
            {
                stars[i].sprite = noStar;
            }


        }


        if (starsEarned == 3) {

            winText.text = "You Win!! ";
            PlayerPrefs.SetInt("Level1", 1);
            PlayerPrefs.Save();

        }
        else
        {
            winText.text = "You Tried! ";
        }
        }

    public void LevelList()
    {
        SceneManager.LoadScene(sceneTo);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

