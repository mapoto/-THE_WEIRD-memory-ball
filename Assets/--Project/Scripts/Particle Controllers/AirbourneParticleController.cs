using UnityEngine;

public class AirbourneParticleController : MonoBehaviour
{
    private ParticleSystem ps;
    public float defaultParticleLinearY;
    public float defaultParticleOrbitalY;
    public float restedNoiseStrength;
    public float unrestedNoiseStrength;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationX = RotationDetector.actualQuaternion.x;
        float rotationY = RotationDetector.actualQuaternion.y;

        bool rested = !RotationDetector.rotated;
        bool triggered = Starter.triggered;

        adjustParticles(triggered, rested, rotationX, rotationY);
    }


    void adjustParticles(bool triggered, bool rested, float x, float y)
    {
        if (ps != null)
        {
            if (triggered)
            {
                particleWhenTriggered(rested, x, y);
            }
            else
            {
                particleWhenNotTriggered(rested, x, y);
            }

        }

    }

    void particleWhenNotTriggered(bool rested, float x, float y)
    {
        var noise = ps.noise;
        var velocity = ps.velocityOverLifetime;

        var rotOverLifetime = ps.rotationOverLifetime;
        var rotBySpeed = ps.rotationBySpeed;

        noise.enabled = !rested;
        rotBySpeed.enabled = !rested;
        rotOverLifetime.enabled = !rested;

        if (rested)
        {
            velocity.orbitalY = 0;
            velocity.radial = 0;
            velocity.y = 0;
            noise.enabled = false;

        }
        else
        {
            velocity.orbitalX = x;
            velocity.orbitalY = y;
            velocity.radial = 0.8f;
            noise.enabled = true;

        }
    }

    void particleWhenTriggered(bool rested, float x, float y)
    {
        var noise = ps.noise;
        var velocity = ps.velocityOverLifetime;

        velocity.radial = 0.8f;
        noise.enabled = true;

        if (rested)
        {
            velocity.orbitalX = defaultParticleLinearY;
            velocity.orbitalY = defaultParticleOrbitalY;
            noise.strength = restedNoiseStrength;
        }
        else
        {
            velocity.orbitalX = x;
            velocity.orbitalY = y;
            noise.strength = unrestedNoiseStrength;

        }
    }
}
