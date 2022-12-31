using UnityEngine;

public class FPSOptimizer : MonoBehaviour
{
    // The target frame rate
    public int targetFrameRate = 60;

    // The time interval to check the frame rate
    public float checkInterval = 1f;

    // The particle systems to adjust
    public ParticleSystem[] particleSystems;

    // The original maximum number of particles in each system
    private int[] originalMaxParticles;

    // The time when the last check was performed
    private float lastCheckTime;

    private void Start()
    {
        // Pre-cache the particle systems and store the original maximum number of particles
        particleSystems = FindObjectsOfType<ParticleSystem>();
        originalMaxParticles = new int[particleSystems.Length];

        for (int i = 0; i < particleSystems.Length; i++)
        {
            originalMaxParticles[i] = particleSystems[i].main.maxParticles;
        }
    }

    private void Update()
    {
        // Check if it is time to check the frame rate
        if (Time.time >= lastCheckTime + checkInterval)
        {
            // Check if the current frame rate is below the target
            bool optimizePerformance = Mathf.RoundToInt(1f / Time.deltaTime) < targetFrameRate;
            Optimize(optimizePerformance);

            // Update the time of the last check
            lastCheckTime = Time.time;
        }
    }

    // Function to optimize performance based on a given condition
    public void Optimize(bool condition)
    {
        if (condition)
        {
            // Increase performance by reducing the number of particles
            for (int i = 0; i < particleSystems.Length; i++)
            {
                // Set the maximum number of particles to half of the original value
                ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystems[i].main.maxParticles];
                int numParticles = particleSystems[i].GetParticles(particles);
                for (int j = 0; j < numParticles; j++)
                {
                    particles[j].remainingLifetime = 0f;
                }
                particleSystems[i].SetParticles(particles, Mathf.RoundToInt(originalMaxParticles[i] * 0.5f));
            }

            // Increase performance by downgrading shadows
            QualitySettings.shadows = ShadowQuality.HardOnly;
        }
        else
        {
            // Restore the original number of particles
            for (int i = 0; i < particleSystems.Length; i++)
            {
                // Set the maximum number of particles to the original value
                ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystems[i].main.maxParticles];
                int numParticles = particleSystems[i].GetParticles(particles);
                for (int j = 0; j < numParticles; j++)
                {
                    particles[j].remainingLifetime = 0f;
                }
                particleSystems[i].SetParticles(particles, Mathf.RoundToInt(originalMaxParticles[i]));
            }

            // Restore shadows
            QualitySettings.shadows = ShadowQuality.All;
        }
    }
}
