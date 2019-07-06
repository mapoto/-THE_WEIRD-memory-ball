using UnityEngine;

public class SkyboxTimelineChanger : MonoBehaviour
{
    public Material skyboxMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox = skyboxMaterial;
        DynamicGI.UpdateEnvironment();
    }
}
