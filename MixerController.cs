using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerController : MonoBehaviour
{
   public AudioMixer audioMixer;
    public Slider musicS;
    public Slider sfxS;



    private void Start()
    {
        musicS.value = PlayerPrefs.GetFloat("Music", 1);
        sfxS.value = PlayerPrefs.GetFloat("SFX", 1f);

        musicS.onValueChanged.AddListener(MusicVolume);
        sfxS.onValueChanged.AddListener(SfxVokume);

    }

    public void MusicVolume(float volume)
    {
        audioMixer.SetFloat("Music", Mathf.Lerp(-80f, 0f, volume));
        PlayerPrefs.SetFloat("Music", volume);

    }

    public void SfxVokume(float volume)
    {
        audioMixer.SetFloat("SFX", Mathf.Lerp(-80f, 0f, volume));
        PlayerPrefs.SetFloat("SFX", volume);
    }
}
