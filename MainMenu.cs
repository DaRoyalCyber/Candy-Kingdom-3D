using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject SettingsUi;
    public GameObject tutorialUI;

 /*   public Button playButton;
    public Button controlsButton;
    public Button tutorialButton;
    public Button backButton;
    public Button exit;*/

    FadeinAndOUt fade;
    void Start()
    {
        mainUI.SetActive(true);
      SettingsUi.SetActive(false);
        tutorialUI.SetActive(false);
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void PlayGame()
    {
        FindObjectOfType<FadeinAndOUt>().StartFade("Level Map");
       // SceneManager.LoadScene("Level Map");
    }

    public void OpenControls()
    {
       // FindObjectOfType<FadeinAndOUt>().StartFadeSame();
       
        mainUI.SetActive(false);
        tutorialUI.SetActive(false);

        SettingsUi.SetActive(true);
    }

    public void OpenTutorial()
    {
      //  FindObjectOfType<FadeinAndOUt>().StartFade();
      
       mainUI.SetActive(false);
        SettingsUi.SetActive(false );


        tutorialUI.SetActive(true);
    }

    public void GoBackToMainPage()
    {
       // FindObjectOfType<FadeinAndOUt>().StartFadeSame();
    
        mainUI.SetActive(true );
        SettingsUi.SetActive(false);
        tutorialUI.SetActive(false);

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}