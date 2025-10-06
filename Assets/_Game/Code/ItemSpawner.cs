using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Настройки спавна")]
    public List<GameObject> objectPrefabs;
    public float destroyDistance = 10f;
    private bool IsFinish = false;
    
    [Header("Ссылки")]
    public Transform player;

    [SerializeField]private GameObject spawnedObject;
    [SerializeField]private int _currentIndexSpawnItem = 0;
    
    [SerializeField] private bool IsActiveObject = false;
    [SerializeField]private bool IsApplySpawnItem = false;
    
    [SerializeField]private float TimerToLastCollect = 0;
    [SerializeField]private float TimeToLastCollect = 5;
    
    protected virtual void Start()
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
        StartCoroutine(ChangeThingsInvoke(i));
    }

    protected virtual IEnumerator ChangeThingsInvoke(int value)
    {
        switch (value)
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
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 1;
        yield return null;
    }
    
    protected virtual IEnumerator SecondThing()
    {
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 2;
        yield return null;
    }
    protected virtual IEnumerator ThirdThing()
    {
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 3;
        yield return null;
    }
    protected virtual IEnumerator FourthThing()
    {
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 4;
        yield return null;
    }
    protected virtual IEnumerator FifthThing()
    {
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 5;
        yield return null;
    }
    protected virtual IEnumerator SixthThing()
    {
        IsActiveObject = false;
        TimerToLastCollect = TimeToLastCollect;
        IsApplySpawnItem = false;
        _currentIndexSpawnItem = 6;
        yield return null;
    }
    
    protected virtual IEnumerator SeventhThing()
    {
        IsFinish = true;
        yield return null;
    }
    
    void Update()
    {
        if(IsFinish) return;
        if (TimerToLastCollect > 0 && IsApplySpawnItem == false) 
        {
            TimerToLastCollect -= Time.deltaTime;
            if (TimerToLastCollect <= 0)
            {
                IsApplySpawnItem = true;
            }
        }

        if (IsApplySpawnItem)
        {
            if (!IsActiveObject)
            {
                SpawnObject();
            }
            else
            {
                CheckObjectsDistance();
            }
        }
        
    }
    
    void SpawnObject()
    {
        Vector3 spawnPosition = GetSpawnPositionOutsideScreen();
        GameObject newObject = Instantiate(objectPrefabs[_currentIndexSpawnItem], spawnPosition, Quaternion.identity);
        spawnedObject = newObject;
        IsActiveObject = true;
    }
    
    Vector3 GetSpawnPositionOutsideScreen()
    {
        Vector3 spawnPos = Vector3.zero;
        Camera mainCamera = Camera.main;
        
        // Случайно выбираем сторону экрана
        int side = Random.Range(0, 4);
        
        switch (side)
        {
            case 0: // Слева
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(-0.1f, Random.Range(0.1f, 0.9f), 10f));
                break;
            case 1: // Справа
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0.1f, 0.9f), 10f));
                break;
            case 2: // Сверху
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), 1.1f, 10f));
                break;
            case 3: // Снизу
                spawnPos = mainCamera.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.9f), -0.1f, 10f));
                break;
        }
        
        return spawnPos;
    }
    
    void CheckObjectsDistance()
    {
        
            float distance = Vector3.Distance(player.position, spawnedObject.transform.position);
            if (distance > destroyDistance)
            {
                Destroy(spawnedObject);
                IsActiveObject = false;
            }
        
    }
}
