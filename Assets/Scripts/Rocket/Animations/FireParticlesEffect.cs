using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class FireParticlesEffect : MonoBehaviour
{
    //��Ч����ʱ��
    //public float timeToDestroy;

    public ParticleSystem rocketFlame;

    void Start()
    {
        //��Ч����ʱ�������destroy��Ч
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
