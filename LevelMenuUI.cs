using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenuUI : MonoBehaviour
{

    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;

     void Start()
    {
        level1.interactable = true;

        bool level1Done = PlayerPrefs.GetInt("Level1", 0) == 1;
        bool level2Done = PlayerPrefs.GetInt("Level2", 0) == 1;
        bool level3Done = PlayerPrefs.GetInt("Level3", 0) == 1;

        level2.interactable = level1Done;
        level3.interactable = level2Done;
        level4.interactable = level3Done;
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
