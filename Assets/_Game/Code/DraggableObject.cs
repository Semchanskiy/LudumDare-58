using UnityEngine;
using UnityEngine.Events;

public class DraggableObject : MonoBehaviour
{
    [System.Serializable]
    public class DragEvent : UnityEvent<GameObject> { }

    [Header("Settings")]
    public bool isDraggable = true;
    [HideInInspector] public bool returnToStart = false;
    [HideInInspector] public string[] compatibleDropTags = { "DropZone" };

    [Header("Events")]
    [HideInInspector] public DragEvent onDragStart;
    [HideInInspector] public DragEvent onDragEnd;
    [HideInInspector] public DragEvent onSuccessfulDrop;
    [HideInInspector] public DragEvent onFailedDrop;
    
    private Vector3 startPosition;
    private Vector3 grabOffset;
    private bool isDragging = false;
    private Transform currentDropZone;
    private Collider2D col2D;
    private int originalSortingOrder;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        col2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSortingOrder = spriteRenderer.sortingOrder;
    }

    void OnMouseDown()
    {
        if (!isDraggable) return;
        
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = transform.position.z;
        grabOffset = transform.position - mouseWorldPos;

        StartDragging();
    }

    void OnMouseUp()
    {
        if (!isDragging) return;

        StopDragging();
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = transform.position.z;
            transform.position = mouseWorldPos + grabOffset;
        }
    }

    private void StartDragging()
    {
        isDragging = true;
        startPosition = transform.position;
        currentDropZone = null;

        col2D.isTrigger = true;
        spriteRenderer.sortingOrder = 100;

        onDragStart?.Invoke(gameObject);
    }

    private void StopDragging()
    {
        isDragging = false;

        col2D.isTrigger = false;
        spriteRenderer.sortingOrder = originalSortingOrder;

        if (currentDropZone != null)
        {
            transform.position = currentDropZone.position;
            onSuccessfulDrop?.Invoke(gameObject);
        }
        else
        {
            if (returnToStart) transform.position = startPosition;
            onFailedDrop?.Invoke(gameObject);
        }

        onDragEnd?.Invoke(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isDragging) return;

        if (IsCompatibleDropTarget(other.gameObject))
        {
            currentDropZone = other.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isDragging) return;

        if (currentDropZone == other.transform)
        {
            currentDropZone = null;
        }
    }

    private bool IsCompatibleDropTarget(GameObject target)
    {
        if (compatibleDropTags == null || compatibleDropTags.Length == 0)
            return true;

        foreach (string tag in compatibleDropTags)
        {
            if (target.CompareTag(tag)) return true;
        }
        return false;
    }
    
    public void SetDraggable(bool state) => isDraggable = state;
    public bool IsDragging() => isDragging;
    public Transform GetCurrentDropZone() => currentDropZone;
    
    public void StartDrag()
    {
        if (!isDraggable) return;
        StartDragging();
    }
    
    public void StopDrag()
    {
        if (!isDragging) return;
        StopDragging();
    }
}
