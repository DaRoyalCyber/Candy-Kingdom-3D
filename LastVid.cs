using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LastVid : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject nextButton;
    public float delayBeforeStart = 2f;

    void Start()
    {
        nextButton.SetActive(false);
        StartCoroutine(PlayVideoWithDelay());
    }
    IEnumerator PlayVideoWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeStart);
        videoPlayer.Play();
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    void OnVideoEnd(VideoPlayer vp)
    {
        nextButton.SetActive(true);
        vp.Pause();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
