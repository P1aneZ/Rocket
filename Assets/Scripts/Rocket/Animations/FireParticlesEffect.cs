using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticlesEffect : MonoBehaviour
{
    //特效持续时间
    public float timeToDestroy;

    void Start()
    {
        //特效持续时间结束就destroy特效
        Destroy(gameObject,timeToDestroy);
    }


}
