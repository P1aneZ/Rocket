using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketSound : MonoBehaviour
{
    public static AudioSource audioSrc;//���岥����

    //��������Ч
    public static AudioClip rocketMoving;
    public static AudioClip rocketExplosion1;
    public static AudioClip rocketExplosion2;
    public static AudioClip rocketExplosion3;
    public static AudioClip rocketReady;
    public static AudioClip rocketHit;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡ�����Ч�ļ�
        rocketMoving = Resources.Load<AudioClip>("Rocket_Moving");
        rocketExplosion1 = Resources.Load<AudioClip>("Rocket_Explosion1");
        rocketExplosion2 = Resources.Load<AudioClip>("Rocket_Explosion2");
        rocketExplosion3 = Resources.Load<AudioClip>("Rocket_Explosion3");
        rocketHit = Resources.Load<AudioClip>("Rocket_Hit");

    }

    public static void PlayRocketMoving()
    {
        audioSrc.PlayOneShot(rocketMoving);
    }

    public static void PlayRocketExplosion()
    {
        int a = Random.Range(1, 4);//����������ֱ�ը��Ч�е�һ��
        if (a == 1)
            audioSrc.PlayOneShot(rocketExplosion1);
        else if (a == 2)
            audioSrc.PlayOneShot(rocketExplosion2);
        else if (a == 3)
            audioSrc.PlayOneShot(rocketExplosion3);
    }

    public static void PlayRocketReady()
    {
        audioSrc.PlayOneShot(rocketReady);
    }

    public static void PlayRocketHit()
    {
        audioSrc.PlayOneShot(rocketHit);
    }

}
