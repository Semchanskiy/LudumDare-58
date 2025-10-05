using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]private float detectionRange = 1f;
    private float speed = 2f; 
    public void Kill()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        
        float distance = Vector3.Distance(transform.position, G.run.Player.transform.position);
        
        if (distance <= detectionRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, G.run.Player.transform.position, speed * Time.deltaTime);
        }
    }
}
