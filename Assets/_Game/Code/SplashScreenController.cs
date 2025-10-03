using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
    [Header("Settings")]
    public float fadeDuration = 1.0f;
    public float delayBetweenFades = 0.5f;
    
    [Header("Reference")]
    public Image panel;
    
    void Start()
    {
        if (panel != null)
        {
            StartCoroutine(FadeRoutine());
        }
        else
        {
            Debug.LogError("Panel не назначена в инспекторе!");
        }
    }
    
    IEnumerator FadeRoutine()
    {
        yield return StartCoroutine(FadePanel(1f, 0f, fadeDuration));
        
        yield return new WaitForSeconds(delayBetweenFades);
        
        yield return StartCoroutine(FadePanel(0f, 1f, fadeDuration));
        SceneManager.LoadScene("Menu");
    }
    
    IEnumerator FadePanel(float startAlpha, float endAlpha, float duration)
    {
        float timer = 0f;
        Color panelColor = panel.color;
        
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, timer / duration);
            
            panelColor.a = alpha;
            panel.color = panelColor;
            
            yield return null;
        }
        panelColor.a = endAlpha;
        panel.color = panelColor;
        
    }
}
