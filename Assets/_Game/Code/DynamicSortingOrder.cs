using UnityEngine;

public class DynamicSortingOrder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    
    [Header("Основные настройки")]
    public int baseOrder = 0;
    public float orderMultiplier = -100f;
    public bool updateInRealTime = true;
    
    [Header("Оптимизация")]
    public float updateFrequency = 0.1f; // Частота обновления в секундах
    private float timer;
    
    [Header("Ограничения")]
    public bool useOrderLimits = false;
    public int minOrder = -1000;
    public int maxOrder = 1000;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateOrder();
        
        // Если не нужно обновлять в реальном времени, отключаем
        if (!updateInRealTime)
        {
            enabled = false;
            Destroy(this);
        }
    }
    
    void Update()
    {
        if (updateInRealTime)
        {
            if (updateFrequency > 0)
            {
                // Обновление с заданной частотой для оптимизации
                timer += Time.deltaTime;
                if (timer >= updateFrequency)
                {
                    UpdateOrder();
                    timer = 0f;
                }
            }
            else
            {
                // Постоянное обновление каждый кадр
                UpdateOrder();
            }
        }
    }
    
    public void UpdateOrder()
    {
        if (spriteRenderer == null) return;
        
        int newOrder = baseOrder + Mathf.RoundToInt(transform.position.y * orderMultiplier);
        
        // Применяем ограничения если нужно
        if (useOrderLimits)
        {
            newOrder = Mathf.Clamp(newOrder, minOrder, maxOrder);
        }
        
        spriteRenderer.sortingOrder = newOrder;
    }
    
    // Ручное обновление сортировки
    public void ForceUpdateOrder()
    {
        UpdateOrder();
    }
    
    // Для отладки в редакторе
    void OnDrawGizmosSelected()
    {
        if (spriteRenderer != null)
        {
            int currentOrder = baseOrder + Mathf.RoundToInt(transform.position.y * orderMultiplier);
            Debug.Log($"Y позиция: {transform.position.y}, Sorting Order: {currentOrder}");
        }
    }
}
