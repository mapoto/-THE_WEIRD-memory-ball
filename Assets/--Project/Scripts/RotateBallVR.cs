using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Valve.VR;
//using Valve.VR.InteractionSystem;

public class RotateBallVR : MonoBehaviour
{
    //public SteamVR_Behaviour_Pose vR_Input;
    public static float h;
    public static float v;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //h = vR_Input.transform.rotation.y;
        //v = vR_Input.transform.rotation.x;

        Debug.Log(h);

        transform.Rotate(v, h, 0);
    }

}
