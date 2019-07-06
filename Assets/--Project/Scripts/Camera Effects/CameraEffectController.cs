using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectController : MonoBehaviour
{
    public GameObject cameraObject;

    CRTCameraEffect crt;
    UnsyncCameraEffect unsync;


    // Start is called before the first frame update
    void Start()
    {
        crt = cameraObject.GetComponent<CRTCameraEffect>();
        unsync = cameraObject.GetComponent<UnsyncCameraEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        bool untriggered = !Starter.triggered;
        bool rotated = RotationDetector.rotated;

        if (untriggered)
        {
            pretriggeredCameraEffect(rotated);

        }
        else
        {
            pretriggeredCameraEffect(false);
        }

    }


    public void pretriggeredCameraEffect(bool rotated)
    {

        unsync.enabled = rotated;
        crt.enabled = rotated;

    }

}
