using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Vinette : MonoBehaviour
{
    [SerializeField] private Shader _shader;
    [SerializeField] private Material _material;
    [SerializeField] private Color _blackColor;
    [SerializeField] private Color _redColor;
    protected virtual void Start()
    {
        _material = new Material(_shader);
        GetComponent<Image>().material = _material;
        G.run.OnChangeCountThings += (i) =>
        {
            ChangeThings(i);
        };
    }

    protected virtual void OnDestroy()
    {
        G.run.OnChangeCountThings -= (i) =>
        {
            ChangeThings(i);
        };
    }

    protected void ChangeThings(int i)
    {
        StopAllCoroutines();
        StartCoroutine(ChangeThingsInvoke());
    }

    protected virtual IEnumerator ChangeThingsInvoke()
    {
        switch (G.run.countThings)
        {
            case 0: yield return ZeroThing(); break;
            case 1: yield return FirstThing(); break;
            case 2: yield return SecondThing(); break;
            case 3: yield return ThirdThing(); break;
            case 4: yield return FourthThing(); break;
            case 5: yield return FifthThing(); break;
            case 6: yield return SixthThing(); break;
            case 7: yield return SeventhThing(); break;
        };
    }
    
    protected virtual IEnumerator ZeroThing()
    {
        yield return null;
    }

    protected virtual IEnumerator FirstThing()
    {
        yield return IncreaseVignetteIntensity( 1.4f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity( 0.7f, 1f,_blackColor);
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        yield return IncreaseVignetteIntensity( 1.4f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity(0.9f, 1f,_blackColor);
        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        yield return IncreaseVignetteIntensity( 1.6f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity( 1f, 1f,_blackColor);
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        yield return IncreaseVignetteIntensity( 1.6f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity( 1f, 2f,_blackColor);
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        yield return IncreaseVignetteIntensity( 1.6f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity( 1.2f, 3f,_redColor);
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        yield return IncreaseVignetteIntensity( 1.6f, 0.4f,_blackColor);
        yield return IncreaseVignetteIntensity( 1.3f, 4f,_redColor);
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        yield return null;
    }
    
    private IEnumerator IncreaseVignetteIntensity(float targetIntensity, float duration, Color targetСolor)
    {
        
        float startIntensity = _material.GetFloat("_Intensity");
        Color startColor = _material.GetColor("_Color");
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
        
            // Плавно изменяем интенсивность
            _material.SetFloat("_Intensity",Mathf.Lerp(startIntensity, targetIntensity, t));
        
            // Плавно изменяем цвет
            _material.SetColor("_Color",Color.Lerp(startColor, targetСolor, t));
        
            yield return null;
        }
    
        _material.SetFloat("_Intensity",targetIntensity);
        _material.SetColor("_Color",targetСolor);


    }
}
