using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GumLevelUI : MonoBehaviour
{
    public static GumLevelUI instance;

    public GameObject Timer;

    private void Awake()
    {
        instance = this;

    }
    public GameObject uiWin;


    public Image[] stars;



    public Sprite goldStar;
    public Sprite noStar;

    public TextMeshProUGUI winText;

    int starsEarned = 0;

    bool levelComplete = false;
    bool dropped = false;
    bool houseSafe = true;


    public Button ok;
    public Button restartLevel;

    float timeLimit = 60f;
    float timeleft;

    bool isTimeUp = false;
    

    public string sceneTo;

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

            if (timeleft <= 0f)
            {
                timeleft = 0f;

                if (!isTimeUp)
                {
                    isTimeUp = true;
                    Fail(); 
                }
            }
            }
    }

    public void DamagedHouse()
    {
        houseSafe = false;
        Fail();
    }
    public void Dropped()
    {
        dropped = true;

    }

    public void Complete()
    {
        if (levelComplete || !houseSafe) return;


            starsEarned = 0;

            if(!isTimeUp) starsEarned++;
            if (houseSafe) starsEarned++;
            if(dropped) starsEarned++;

            UIUpdate();
            levelComplete = true;
            
          

    }
    void UIUpdate()
    {
        uiWin.SetActive(true);


        for (int i = 0; i < stars.Length; i++)
        {
            if (i < starsEarned)
            {

                stars[i].sprite = goldStar;
            }
            else
            {
                stars[i].sprite = noStar;
            }


        }

        if (starsEarned == 3)
        {

            winText.text = "You Win!! ";
            PlayerPrefs.SetInt("Level3", 1);
            PlayerPrefs.Save();


        }
        else if(starsEarned > 0)
        {
            winText.text = "You Tried! ";
        }
        else
        {
            winText.text = "you Faild!";
        }
    }
    public void Fail()
    {
        levelComplete = true;
        starsEarned = 0;

        for(int i =0 ;  i < stars.Length; i++)
        {
            stars[i].sprite = noStar;
        }
        uiWin.SetActive(true );
        winText.text = "You Failed!";
       
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

