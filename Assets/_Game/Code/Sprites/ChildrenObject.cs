using UnityEngine;

public class ChildrenObject : MonoBehaviour
{
    [SerializeField] private Shader _shader;
    public bool ChangeStandartShader = true;
    void Start()
    {
        if (ChangeStandartShader)
        {
            GetComponent<Renderer>().material = new Material(_shader);
            GetComponent<Renderer>().material.SetFloat("_PivotY", 1);
            GetComponent<Renderer>().material.SetColor("_Color", GetComponent<SpriteRenderer>().color);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
