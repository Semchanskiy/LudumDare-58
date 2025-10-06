using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHSFlikerSpawner : MonoBehaviour
{
    [Header("Timing")]
    public float Time = 0.1f;

    [Header("Scale & Alpha")]
    public Vector2 scaleRange = new Vector2(0.5f, 1.5f);
    public Vector2 alphaRange = new Vector2(0.2f, 1f);

    private Camera mainCamera;
    [SerializeField]private List<SpriteRenderer> pool = new List<SpriteRenderer>();
    [SerializeField] private List<Sprite> poolSprite = new List<Sprite>();

    void Start()
    {
        G.run.OnChangeCountThings += (i) =>
        {
            ChangeThings(i);
        };
        mainCamera = Camera.main;
    }



    System.Collections.IEnumerator FlickerObjects()
    {
        while (true)
        {
            float waitTime = Time + Random.Range(-0.05f, 0.05f);
            yield return new WaitForSeconds(waitTime);

            SpawnFlicker();
        }
    }

    void SpawnFlicker()
    {
        if (pool.Count == 0) return;

        // Берем первый объект из пула
        SpriteRenderer obj = pool[0];
        pool.RemoveAt(0);
        pool.Add(obj); // Отправляем в конец списка

        // Случайная дистанция до камеры
        float distance = 1;
        // Случайная позиция в пределах камеры (viewport)
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);
        Vector3 viewportPos = new Vector3(randomX, randomY, distance);
        Vector3 worldPos = mainCamera.ViewportToWorldPoint(viewportPos);

        obj.transform.position = worldPos;

        // Рандомный масштаб
        float scale = Random.Range(scaleRange.x, scaleRange.y);
        obj.transform.localScale = Vector3.one * scale;

        // Рандомная прозрачность (если есть SpriteRenderer)
        SpriteRenderer sr = obj.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = Random.Range(alphaRange.x, alphaRange.y);
    
            // Случайный выбор цвета: черный, белый или красный
            Color randomColor = Random.Range(0, 3) switch
            {
                0 => Color.black,      // Черный
                1 => Color.white,      // Белый
                2 => Color.red,        // Красный
                _ => Color.white       // По умолчанию белый (на всякий случай)
            };
    
            // Сохраняем альфа-канал из предыдущего цвета
            randomColor.a = c.a;
            sr.color = randomColor;
        }

        // Включаем объект
        obj.transform.Rotate(new Vector3(0,0,Random.Range(0f,360f)));
        obj.sprite = poolSprite[Random.Range(0, poolSprite.Count)];
        obj.gameObject.SetActive(true);

        // Выключаем через случайное время
        StartCoroutine(DeactivateAfterTime(obj.gameObject, Random.Range(0.1f, 0.3f)));
    }

    System.Collections.IEnumerator DeactivateAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
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
        
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        StartCoroutine(FlickerObjects());
        Time = 1f;
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        StartCoroutine(FlickerObjects());
        Time = 0.5f;
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        StartCoroutine(FlickerObjects());
        Time = 0.1f;
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        yield return null;
    }
}
