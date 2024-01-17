using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticlesEffect : MonoBehaviour
{
    //特效持续时间
    public float timeToDestroy;

    void Start()
    {
        Destroy(gameObject,timeToDestroy);
    }

}
