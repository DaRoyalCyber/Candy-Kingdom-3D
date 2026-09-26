using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using System.Collections;

public class VideoEndHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject nextButton;

    public float delay = 1.5f;

    void Start()
    {
        nextButton.SetActive(false);
        StartCoroutine(vidDelay());
        videoPlayer.loopPointReached += OnVideoEnd;
    }
    IEnumerator vidDelay()
    {
        yield return new WaitForSeconds(delay);
        videoPlayer.Play();

    }
    void OnVideoEnd(VideoPlayer vp)
    {
        nextButton.SetActive(true); 
        vp.Pause();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Level Map"); 
    }
}