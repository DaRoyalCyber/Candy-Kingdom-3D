using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GumAudio : MonoBehaviour
{

    public static GumAudio instance;

    public AudioSource gumAudioShoot;
    public AudioSource enemyjumpAudio;

    public AudioSource enemyEnter;

    public AudioSource bgLevelMusic;

    

    private void Awake()
    {
    instance = this;
        }
    private void Start()
    {
        bgLevelMusic.Play();
    }
}

   

