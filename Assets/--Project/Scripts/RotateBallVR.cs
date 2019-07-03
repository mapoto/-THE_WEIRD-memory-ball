using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class RotateBallVR : MonoBehaviour
{
    public GameObject cameraGameObject;
    public Quaternion actualQuaternion;
    public Quaternion lastQuaternion;

    public float timelineTriggerValue = 300f;

    private UnsyncCameraEffect unsync;
    private CRTCameraEffect crt;


    public static float handlerY;
    public static float handlerX;
    public static float handlerZ;

    // Start is called before the first frame update
    void Start()
    {
        actualQuaternion = gameObject.transform.localRotation;
        lastQuaternion = Quaternion.identity;

        unsync = cameraGameObject.GetComponent<UnsyncCameraEffect>();
        crt = cameraGameObject.GetComponent<CRTCameraEffect>();

        unsync.enabled = false;
        crt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        actualQuaternion = gameObject.transform.localRotation;
        checkThreshold();

    }

    bool isRotated()
    {
        return (actualQuaternion != lastQuaternion);
    }

    void checkThreshold()
    {

        if (isRotated())
        {
            float diff = Quaternion.Angle(actualQuaternion, lastQuaternion);

            if(diff >= 5f)
            {
                timelineTriggerValue -= diff;
                unsync.enabled = true;
                crt.enabled = true;
            }
            else
            {
                unsync.enabled = false;
                crt.enabled = false;
            }

            lastQuaternion = actualQuaternion;


        }
    }


}
