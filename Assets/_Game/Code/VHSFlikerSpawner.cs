using System.Collections.Generic;
using UnityEngine;

public class VHSFlikerSpawner : MonoBehaviour
{
    [Header("Timing")]
    public float minTime = 0.05f;
    public float maxTime = 0.2f;

    [Header("Distance from Camera")]
    public float minDistance = 3f;
    public float maxDistance = 6f;

    [Header("Scale & Alpha")]
    public Vector2 scaleRange = new Vector2(0.5f, 1.5f);
    public Vector2 alphaRange = new Vector2(0.2f, 1f);

    private Camera mainCamera;
    [SerializeField]private List<SpriteRenderer> pool = new List<SpriteRenderer>();
    [SerializeField] private List<Sprite> poolSprite = new List<Sprite>();

    void Start()
    {
        mainCamera = Camera.main;
        InitializePool();
        StartCoroutine(FlickerObjects());
    }

    void InitializePool()
    {

    }

    System.Collections.IEnumerator FlickerObjects()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
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
        float distance = Random.Range(minDistance, maxDistance);
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
            sr.color = c;
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
}
