using UnityEngine;
using UnityEngine.UI;

public class Starter : MonoBehaviour
{
    public GameObject controller;
    public GameObject timelineController;
    public AudioClip vhsRolling;

    public float timelineTriggerValue = 1000f;

    private SkyboxControllerScript skyboxControllerScript;
    private RotationDetector detector;
    private AudioSource audioSource;
    private UnsyncCameraEffect unsync;
    private CRTCameraEffect crt;


    public static bool triggered = false;

    void Awake()
    {
        skyboxControllerScript = GetComponent<SkyboxControllerScript>();
        audioSource = GetComponent<AudioSource>();

        detector = controller.GetComponent<RotationDetector>();

    }

    // Start is called before the first frame update
    void Start()
    {
        triggered = false;
        audioSource.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {

        bool rotated = RotationDetector.rotated;
        float offset = RotationDetector.offset;

        Debug.Log(offset);

        timelineController.SetActive(triggered);

        if (!triggered)
        {
            checkRotation(rotated, offset);
        }
        else
        {
            audioSource.enabled = false;
        }
    }



    void playPreTrigger(bool rotated, float offset)
    {
        audioSource.loop = rotated;
        timelineTriggerValue -= offset;

        if (rotated)
        {
            audioSource.clip = vhsRolling;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = null;
            audioSource.Stop();
        }

    }

    void checkRotation(bool rotated, float offset)
    {

        playPreTrigger(rotated, offset);

        if (timelineTriggerValue <= 0f)
        {
            timelineTriggerValue = 0f;
            triggered = true;
            Debug.Log(triggered);
        }

    }



}
