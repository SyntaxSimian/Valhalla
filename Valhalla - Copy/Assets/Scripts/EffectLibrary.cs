using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectLibrary : MonoBehaviour
{

    public ParticleSystem impact;
    public ParticleSystem tracer;
    public ParticleSystem SmallEnemyKill;
    
    void Start ()
    {
        EffectLibraryAgent.setEffectLibrary(this);
	}

    public void SpawnImpact(Vector3 location)
    {
        impact.transform.position = location;
        impact.Play();
    }
    public void SpawnTracer(Vector3 location)
    {
        tracer.transform.position = location;
        tracer.Play();
    }
    public void SpawnSmallEnemyKill(Vector3 location)
    {
        SmallEnemyKill.transform.position = location;
        SmallEnemyKill.Play();
    }
}
