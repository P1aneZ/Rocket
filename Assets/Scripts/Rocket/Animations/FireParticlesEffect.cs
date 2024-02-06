using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class FireParticlesEffect : MonoBehaviour
{
    //特效持续时间
    //public float timeToDestroy;

    public ParticleSystem rocketFlame;

    void Start()
    {
        //特效持续时间结束就destroy特效
        //Destroy(gameObject,timeToDestroy);
        rocketFlame = GetComponent<ParticleSystem>(); 
    }

    public void Play()
    {
        var emission = rocketFlame.emission;
        emission.enabled = true;
        rocketFlame.Play();
    }

    public void Pause()
    {
        var emission = rocketFlame.emission;
        emission.enabled = false;
    }

}
