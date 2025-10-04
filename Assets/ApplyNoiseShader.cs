using UnityEngine;

public class ApplyNoiseShader : MonoBehaviour
{
   
    [Range(0, 1)]
    public float noiseIntensity = 0.1f;
    public Texture2D noiseTexture;
    public float noiseScale = 1.0f;

    void Start()
    {
        // Получаем компонент SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Создаем новый материал с шейдером "Custom/SpriteWithNoise"
        Shader shader = Shader.Find("Custom/SpriteWithNoise");
        if (shader == null)
        {
            Debug.LogError("Shader not found!");
            return;
        }

        Material material = new Material(shader);

        // Устанавливаем текстуру шума и параметры
        material.SetTexture("_NoiseTex", noiseTexture);
        material.SetFloat("_NoiseIntensity", noiseIntensity);
        material.SetFloat("_NoiseScale", noiseScale);

        // Назначаем материал спрайту
        spriteRenderer.material = material;
    }
}
