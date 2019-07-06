using UnityEngine;

public class SkyboxControllerScript : MonoBehaviour
{
    public Material[] skyboxMaterials;
    private int size;

    void Start()
    {
        RenderSettings.skybox = skyboxMaterials[0];
        size = skyboxMaterials.Length - 1;
    }

    void Update()
    {

        if (!RotationDetector.rotated)
        {

            PauseSkybox();
        }
        else
        {
            RewindSkybox();
        }
    }

    public void PauseSkybox()
    {
        RenderSettings.skybox = skyboxMaterials[0];

        float lerp = (Mathf.PingPong(Time.time, 2f)) + 1f;
        int rot = (int)(Random.Range(90, 100) * Time.deltaTime);

        RenderSettings.skybox.SetFloat("_Exposure", lerp);
        RenderSettings.skybox.SetFloat("_Rotation", rot);
        DynamicGI.UpdateEnvironment();

    }

    public void RewindSkybox()
    {
        int rot = (int)(Random.Range(90, 100) * Time.deltaTime);

        RenderSettings.skybox = skyboxMaterials[1];
        RenderSettings.skybox.SetFloat("_Rotation", rot);
        DynamicGI.UpdateEnvironment();
    }


}
