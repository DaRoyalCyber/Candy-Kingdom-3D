using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAudio : MonoBehaviour
{
   public static SpinningAudio  instance;

    public AudioSource background;       
    public AudioSource TriggerButtomn;  


 
    public AudioSource objectFalling;
    public AudioSource candyBullet; 


   private void Awake()
    {
    instance = this;
    }

    private void Start() {
        background.Play();
    }

  


    public void PlayObjectFalling()
    {
        objectFalling.Play();
    }

    public void PlayCandyBullet()
    {
        candyBullet.Play();
    }




}
