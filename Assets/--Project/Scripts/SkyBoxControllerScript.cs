using UnityEngine;

public class SkyBoxControllerScript : MonoBehaviour
{

    public Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTheSkybox();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeTheSkybox()
    {
        int random = Random.Range(0, materials.Length - 1);
        RenderSettings.skybox = materials[random];
    }
}
