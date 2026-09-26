using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    public Button backButton;
    public AudioMixer audioMixer; 

    void Start()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectsSlider.onValueChanged.AddListener(SetEffectsVolume);
        backButton.onClick.AddListener(GoBackToMainPage);
    }

    void SetMusicVolume(float value)
    {
        AudioListener.volume = value;
    }

    void SetEffectsVolume(float value)
    {
        audioMixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
    }

    void GoBackToMainPage()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainPage");
    }
}