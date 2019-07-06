using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotationController : MonoBehaviour
{

    public static float orbitX;
    public static float orbitY;
    public static float orbitZ;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // This is for mouse. Change the input into VR Controller
        orbitX = Input.GetAxis("Mouse X");
        orbitY = Input.GetAxis("Mouse Y");
        orbitZ = Input.mouseScrollDelta.y;
        transform.Rotate(orbitX,orbitY,orbitZ);

    }
}
