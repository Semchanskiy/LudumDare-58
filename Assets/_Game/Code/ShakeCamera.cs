using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShakeCamera : MonoBehaviour
{
    [Header("Настройки шейка")]
    [SerializeField] private float defaultDuration = 0.5f;
    [SerializeField] private float defaultMagnitude = 0;

    private bool isShaking = false;

    private void Start()
    {
        
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
        yield return OneShakeCoroutine(0.5f, 0.01f);
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        yield return OneShakeCoroutine(0.5f, 0.02f);

        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        yield return OneShakeCoroutine(0.5f, 0.05f);
        yield return ShakeCoroutine(0.5f, 0.01f);
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        yield return OneShakeCoroutine(0.5f, 0.05f);
        yield return ShakeCoroutine(0.5f, 0.02f);
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        yield return OneShakeCoroutine(0.5f, 0.07f);
        yield return ShakeCoroutine(0.5f, 0.03f);
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        yield return OneShakeCoroutine(0.5f, 0.1f);
        yield return ShakeCoroutine(0.5f, 0.04f);
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        yield return null;
    }
    

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        isShaking = true;
        while (isShaking)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                // Плавное уменьшение интенсивности
                float currentMagnitude = magnitude * (1 - (elapsed / duration));
            
                // Случайное смещение с плавным затуханием
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition += new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
    private IEnumerator OneShakeCoroutine(float duration, float magnitude)
    {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                // Плавное уменьшение интенсивности
                float currentMagnitude = magnitude * (1 - (elapsed / duration));
            
                // Случайное смещение с плавным затуханием
                float x = Random.Range(-1f, 1f) * magnitude;
                float y = Random.Range(-1f, 1f) * magnitude;

                transform.localPosition += new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }
    }
}
