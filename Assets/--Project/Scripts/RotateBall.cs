using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class RotateBall : MonoBehaviour
{

    public static float h;
    public static float v;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // This is for mouse. Change the input into VR Controller
        h = CrossPlatformInputManager.GetAxis("Mouse X");
        v = CrossPlatformInputManager.GetAxis("Mouse Y");
        transform.Rotate(v,h,0);

    }
}
