using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public GameObject ball;
    Quaternion lastRotation;
    Quaternion actualRotation;
    ParticleSystem ps;

    public float particleOrbitalX;
    public float particleOrbitalY;
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {

        lastRotation = ball.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        var noise = ps.noise;
        var velocity = ps.velocityOverLifetime;

        if (ps != null)
        {
            if (isRotated())
            {
                noise.strength = 0;
                velocity.orbitalX = RotateBall.h;
                velocity.orbitalY = RotateBall.v;
            }
            else
            {
                velocity.orbitalX = particleOrbitalX;
                velocity.orbitalY = particleOrbitalY;
            }

        }

    }

    bool isRotated()
    {
        actualRotation = ball.transform.rotation;
        if (!actualRotation.Equals(lastRotation))
        {
            lastRotation = actualRotation;
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
