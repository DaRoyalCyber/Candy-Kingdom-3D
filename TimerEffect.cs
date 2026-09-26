using UnityEngine;
using TMPro;

public class TimerEffect : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float shakeIntensity = 5f;
    public float effectDuration = 0.5f;
    public Color normalColor = Color.white;
    public Color alertColor = Color.red;
    public int normalFontSize = 36;
    public int alertFontSize = 50;

    private float timer = 0f;
    private bool effectPlayed = false;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = timerText.rectTransform.localPosition;
        timerText.color = normalColor;
        timerText.fontSize = normalFontSize;
    }

    void Update()
    {
        
        timer += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

        
        if (!effectPlayed && timer >= 60f)
        {
            effectPlayed = true;
            StartCoroutine(PlayAlertEffect());
        }
    }

    System.Collections.IEnumerator PlayAlertEffect()
    {
        float elapsed = 0f;

        
        timerText.color = alertColor;
        timerText.fontSize = alertFontSize;

        
        while (elapsed < effectDuration)
        {
            Vector3 shakeOffset = Random.insideUnitCircle * shakeIntensity;
            timerText.rectTransform.localPosition = originalPosition + shakeOffset;
            elapsed += Time.deltaTime;
            yield return null;
        }

        
        timerText.rectTransform.localPosition = originalPosition;
        timerText.color = normalColor;
        timerText.fontSize = normalFontSize;
    }
}