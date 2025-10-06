using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CryBranch : MonoBehaviour
{
    private bool isShaking = false;
    private float shakeMagnitude = 0f;
    [SerializeField] private GameObject _body;
    [SerializeField] private Transform _cry;
    [SerializeField] private AudioSource _audioSource;
    void Start()
    {
        StartCoroutine(ShakeCoroutine(0.5f));
        _body.SetActive(false);
        if (G.run)
        {
            G.run.OnChangeCountThings += (stage) =>
            {
                ChangeThings(stage);
            };
        }
    }

    private void OnDestroy()
    {
        if (G.run)
        {
            G.run.OnChangeCountThings -= (stage) =>
            {
                ChangeThings(stage);
            };
        }
    }
    
    private void ChangeThings(int i)
    {
        StartCoroutine(ChangeThingsInvoke());
    }

    private void Update()
    {
        if (_body.activeSelf == true)
        {
            // Вычисляем дистанцию до целевого объекта
            float distance = Vector3.Distance(transform.position, G.run.Player.transform.position);
        
            // Нормализуем дистанцию (0 = очень близко, 1 = далеко)
            float normalizedDistance = Mathf.Clamp01(distance / 5);
        
            // Инвертируем значение (1 = очень близко, 0 = далеко)
            float proximityFactor = 1f - normalizedDistance;
        
            // Вычисляем масштаб на основе близости
            float targetScale = Mathf.Lerp(1f, 1.3f, proximityFactor);
            shakeMagnitude = Mathf.Lerp(0f, 0.05f, proximityFactor);
            
            _audioSource.volume = Mathf.Lerp(0f, 1f, proximityFactor);
            _cry.localScale = Vector3.one * targetScale;
        }
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

    protected IEnumerator ZeroThing()
    {
        yield return null;
    }
    protected IEnumerator FirstThing()
    {
        
        yield return null;
    }
    
    protected IEnumerator SecondThing()
    {
        yield return null;
    }
    protected IEnumerator ThirdThing()
    {
        if (Random.Range(0, 100) < 30)
        {
            _body.SetActive(true);
        }
        yield return null;
    }
    protected IEnumerator FourthThing()
    {
        if (Random.Range(0, 100) < 50)
        {
            _body.SetActive(true);
        }
        yield return null;
    }
    protected IEnumerator FifthThing()
    {
        
        yield return null;
    }
    protected IEnumerator SixthThing()
    {
        if (Random.Range(0, 100) < 100)
        {
            _body.SetActive(true);
        }
        yield return null;
    }
    
    protected IEnumerator SeventhThing()
    {
        yield return null;
    }
    private IEnumerator ShakeCoroutine(float duration)
    {
        isShaking = true;
        while (isShaking)
        {
            float elapsed = 0f;

            while (elapsed < duration)
            {
                
                float x = Random.Range(-1f, 1f) * shakeMagnitude;
                float y = Random.Range(-1f, 1f) * shakeMagnitude;

                transform.localPosition += new Vector3(x, y, 0);

                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
    
}
