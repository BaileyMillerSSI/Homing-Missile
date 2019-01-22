using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructOnParticleEnd : MonoBehaviour
{
    private ParticleSystem parSystem;

    // Start is called before the first frame update
    void Start()
    {
        parSystem = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (parSystem.particleCount == 0)
        {
            Destroy(this);
        }
    }
}
