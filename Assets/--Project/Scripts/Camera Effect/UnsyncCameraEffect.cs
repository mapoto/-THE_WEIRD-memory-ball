using UnityEngine;

public class UnsyncCameraEffect : MonoBehaviour
{
    public float speed = 1;
    private float position = 0;
    private Material material;

    void Awake()
    {
        material = new Material(Shader.Find("Hidden/VUnsync"));
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        position += speed * 0.1f * Time.deltaTime;
        position = position%1f;
        material.SetFloat("_ValueX", position);

        RenderTexture renderTexture = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);

        Graphics.Blit(source, renderTexture, material);
        Graphics.Blit(renderTexture, destination, material);
        RenderTexture.ReleaseTemporary(renderTexture);

    }
}
