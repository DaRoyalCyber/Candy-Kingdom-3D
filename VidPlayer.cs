using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    public static VidPlayer instance;
    public VideoPlayer vid;
    private void Awake()
    {
     
    }


    private void Start()
    {
        StartCoroutine(PlayerDelay());
    }

   
    IEnumerator PlayerDelay()
    {
        yield return new WaitForSeconds(0.50f);
        vid.Play();
    }
}
