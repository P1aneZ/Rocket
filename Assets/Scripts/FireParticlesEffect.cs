using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticlesEffect : MonoBehaviour
{
    //��Ч����ʱ��
    public float timeToDestroy;

    void Start()
    {
        Destroy(gameObject,timeToDestroy);
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("�����ɹ�");
        }
    }

}
