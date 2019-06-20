using UnityEngine;

public class ParticleController : MonoBehaviour
{
    Transform ball;
    Quaternion lastRotation;
    Quaternion actualRotation;
    ParticleSystem ps;

    public float particleOrbitalX;
    public float particleOrbitalY;
    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        ball = GetComponentInParent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {

        lastRotation = ball.rotation;

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
        actualRotation = ball.rotation;
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
