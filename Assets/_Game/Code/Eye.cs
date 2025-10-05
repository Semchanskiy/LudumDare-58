using UnityEngine;

public class Eye : MonoBehaviour
{
    [Header("Настройки движения")]
    public float moveSpeed = 2f;          // Скорость движения
    public float directionChangeInterval = 1f; // Интервал смены направления
    public float movementRadius = 0.1f;   // Радиус движения внутри глаза
    
    [Header("Границы глаза")]
    public Transform eyeBoundary;         // Родительский объект глаза (для границ)
    public float boundaryOffset = 0.05f;  // Отступ от границ глаза
    
    private Vector3 targetPosition;
    private Vector3 initialLocalPosition;
    private float timeSinceLastDirectionChange;
    
    void Start()
    {
        // Сохраняем начальную позицию зрачка
        initialLocalPosition = transform.localPosition;
        
        // Генерируем первую целевую позицию
        GenerateNewTargetPosition();
    }
    
    void Update()
    {
        // Обновляем таймер
        timeSinceLastDirectionChange += Time.deltaTime;
        
        // Меняем направление по истечении интервала или при достижении цели
        if (timeSinceLastDirectionChange >= directionChangeInterval || 
            Vector3.Distance(transform.localPosition, targetPosition) < 0.01f)
        {
            GenerateNewTargetPosition();
            timeSinceLastDirectionChange = 0f;
        }
        
        // Двигаемся к целевой позиции
        MoveTowardsTarget();
    }
    
    void GenerateNewTargetPosition()
    {
        // Генерируем случайную позицию в пределах радиуса
        Vector2 randomCircle = Random.insideUnitCircle * movementRadius;
        Vector3 randomOffset = new Vector3(randomCircle.x, randomCircle.y, 0);
        
        // Вычисляем новую целевую позицию
        targetPosition = initialLocalPosition + randomOffset;
        
        // Ограничиваем позицию границами глаза
        if (eyeBoundary != null)
        {
            targetPosition = ClampPositionToEyeBoundary(targetPosition);
        }
    }
    
    void MoveTowardsTarget()
    {
        // Плавное движение к целевой позиции
        transform.localPosition = Vector3.Lerp(
            transform.localPosition, 
            targetPosition, 
            moveSpeed * Time.deltaTime
        );
    }
    
    Vector3 ClampPositionToEyeBoundary(Vector3 position)
    {
        if (eyeBoundary == null) return position;
        
        // Получаем локальные границы глаза
        Vector3 eyeBounds = GetEyeBoundarySize();
        
        // Ограничиваем позицию с учетом отступа
        position.x = Mathf.Clamp(
            position.x, 
            initialLocalPosition.x - eyeBounds.x + boundaryOffset, 
            initialLocalPosition.x + eyeBounds.x - boundaryOffset
        );
        
        position.y = Mathf.Clamp(
            position.y, 
            initialLocalPosition.y - eyeBounds.y + boundaryOffset, 
            initialLocalPosition.y + eyeBounds.y - boundaryOffset
        );
        
        return position;
    }
    
    Vector3 GetEyeBoundarySize()
    {
        // Возвращает размер границ глаза (можно настроить под вашу модель)
        if (eyeBoundary != null)
        {
            Renderer renderer = eyeBoundary.GetComponent<Renderer>();
            if (renderer != null)
            {
                return renderer.bounds.extents;
            }
        }
        
        // Значения по умолчанию
        return new Vector3(0.2f, 0.15f, 0f);
    }
    
    // Метод для ручного вызова смены направления (можно использовать для реакции на события)
    public void ChangeDirectionImmediately()
    {
        GenerateNewTargetPosition();
        timeSinceLastDirectionChange = 0f;
    }
    
    // Метод для настройки параметров движения из других скриптов
    public void SetMovementParameters(float speed, float interval, float radius)
    {
        moveSpeed = speed;
        directionChangeInterval = interval;
        movementRadius = radius;
    }
}
