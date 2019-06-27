using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectController : MonoBehaviour
{
    public Transform ball;
    public GameObject fpsController;
    Quaternion lastRotation;
    Quaternion actualRotation;

    CRTCameraEffect crt;
    UnsyncCameraEffect unsync;


    // Start is called before the first frame update
    void Start()
    {
        crt = fpsController.GetComponent<CRTCameraEffect>();
        unsync = fpsController.GetComponent<UnsyncCameraEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotated())
        {
            unsync.enabled = true;
            crt.enabled = true;

            Quaternion rotationRate = Quaternion.Lerp(lastRotation,actualRotation,0.5f);
            unsync.speed = rotationRate.y * 10f;
            lastRotation = actualRotation;

        }
        else
        {
            unsync.enabled = false;
            crt.enabled = false;
        }
    }
    bool isRotated()
    {
        actualRotation = ball.rotation;
        if (!actualRotation.Equals(lastRotation))
        {
            Debug.Log("is rotated");
            return true;
        }
        else
        {
            Debug.Log("not");
            return false;
        }
    }
}
