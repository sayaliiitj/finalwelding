using UnityEngine;

public class WeldEffectActivator : MonoBehaviour
{
    public Transform weldArea;
    public Transform electrode;
    public GameObject weldGlowObject;

    private ParticleSystem[] allParticles;
    public float minDistance = 0.002f; // 2 mm
    public float maxDistance = 0.005f; // 5 mm

    void Start()
    {
        if (weldGlowObject != null)
            allParticles = weldGlowObject.GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (weldArea == null || electrode == null || allParticles == null)
            return;

        float distance = Vector3.Distance(weldArea.position, electrode.position);

        if (distance >= minDistance && distance <= maxDistance)
        {
            foreach (var ps in allParticles)
            {
                if (!ps.isPlaying)
                    ps.Play();
            }
        }
        else
        {
            foreach (var ps in allParticles)
            {
                if (ps.isPlaying)
                    ps.Stop();
            }
        }
    }
}
