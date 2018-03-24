using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemDestroy : MonoBehaviour
{
    private ParticleSystem pSystem;

    void Start()
    {
	   pSystem = gameObject.GetComponent<ParticleSystem>();

    }//Start

    void Update() { if (!pSystem.IsAlive()) Destroy(gameObject); }

    void OnBecameInvisible () { Destroy(gameObject); }

}//public class ParticleSystemDestroy
