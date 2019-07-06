using UnityEngine;

// to be attached on controller right
public class RotationDetector : MonoBehaviour
{
    public static Quaternion actualQuaternion;
    public static Quaternion lastQuaternion;

    public static float offset;
    public static bool rotated;
    void Start()
    {
        actualQuaternion = gameObject.transform.localRotation;
        lastQuaternion = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        checkRotation();
    }

    private void checkRotation()
    {
        actualQuaternion = gameObject.transform.localRotation;
        offset = getRotationValue();
        rotated = isRotated();
        lastQuaternion = actualQuaternion;
    }
    
    private float getRotationValue()
    {
        return Mathf.Abs(Quaternion.Angle(actualQuaternion, lastQuaternion));
    }

    private bool isRotated()
    {
        float diff = getRotationValue();
        return (diff > 1.0f);
    }


}
