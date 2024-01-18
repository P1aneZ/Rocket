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

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("攻击成功");
        }
    }

}
