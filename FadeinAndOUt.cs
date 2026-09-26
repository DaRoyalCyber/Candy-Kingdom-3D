using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeinAndOUt : MonoBehaviour
{

    public Image fadeImage;

    Animator anim;

    public float fadeTime = 1f;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void StartFade(string sceneName)
    { 
    
    }
    public void loadNext()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));

    }
    IEnumerator LoadLevel(int level)
    {

        anim.SetTrigger("Clouds");

        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(level);

    }
        /*
        public static FadeinAndOUt instance;
        public Image fadeImage;

        Animator anim;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject); 
                return;
            }
            anim = GetComponentInChildren<Animator>();

        }

        public void StartFade(string sceneName)
        {
            StartCoroutine(FadeAndSwitchScene(sceneName));
        }

        IEnumerator FadeAndSwitchScene(string sceneName)
        {
            anim.SetTrigger("Clouds");

            float animationLength = anim.GetCurrentAnimatorStateInfo(0).length; // Get animation duration
            yield return new WaitForSeconds(animationLength);

            SceneManager.LoadScene(sceneName);

            anim.SetTrigger("Out");
        }

        */
    }
