using UnityEngine;
[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class OldFilmPostProces : MonoBehaviour
{
    public Material filmMat;

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (filmMat != null)
            Graphics.Blit(src, dst, filmMat);
        else
            Graphics.Blit(src, dst);
    }
}
