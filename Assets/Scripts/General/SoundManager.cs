using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    //������Ч
    public static AudioSource audioSrc;//���岥����
   
    //��������Ч
    public static AudioClip rocketMoving;
    public static AudioClip rocketExplosion1;
    public static AudioClip rocketExplosion2;
    public static AudioClip rocketExplosion3;
    public static AudioClip rocketReady;
    public static AudioClip rocketHit;

    //���������Ч
    public static AudioClip enemyAttackFemale;
    public static AudioClip enemyDeadFemale;
    public static AudioClip enemyHurtFemale1;
    public static AudioClip enemyHurtFemale2;
    public static AudioClip enemyHurtFemale3;

    //�ݻ�װ���й���Ч
    public static AudioClip steamEngineExplosion;
    public static AudioClip steamEngineHurt;

    //������Ч
    public static AudioClip doorOpen;

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

        //��ȡŮ������Ч�ļ�
        enemyAttackFemale = Resources.Load<AudioClip>("Enemy_Attack_Female");
        enemyDeadFemale = Resources.Load<AudioClip>("Enemy_Dead_Female");
        enemyHurtFemale1 = Resources.Load<AudioClip>("Enemy_Hurt_Female1");
        enemyHurtFemale2 = Resources.Load<AudioClip>("Enemy_Hurt_Female2");
        enemyHurtFemale3 = Resources.Load<AudioClip>("Enemy_Hurt_Female3");

        //��ȡ�ݻ�װ����Ч�ļ�
        steamEngineExplosion= Resources.Load<AudioClip>("SteamEngine_Explosion");
        steamEngineHurt = Resources.Load<AudioClip>("SteamEngine_Hurt");

        //��ȡ������Ч�ļ�
        doorOpen= Resources.Load<AudioClip>("Door_Open");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayRocketMoving()
    {
        audioSrc.PlayOneShot(rocketMoving);
    }

    public static void StopPlayRocketMoving()
    {
        audioSrc.Stop();
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

    public static void PlayEnemyAttackFemale()
    {
        audioSrc.PlayOneShot(enemyAttackFemale);
    }

    public static void PlayEnemyDeadFemale()
    {
        audioSrc.PlayOneShot(enemyDeadFemale);
    }

    public static void PlayEnemyHurtFemale()
    {
        int a = Random.Range(1, 4);//�����������Ů����������Ч��һ��
        if (a == 1)
            audioSrc.PlayOneShot(enemyHurtFemale1);
        else if (a == 2)
            audioSrc.PlayOneShot(enemyHurtFemale2);
        else if (a == 3)
            audioSrc.PlayOneShot(enemyHurtFemale3);
    }

    public static void PlaySteamEngineExplosion()
    {
        audioSrc.PlayOneShot(steamEngineExplosion);
    }

    public static void PlaySteamEngineHurt()
    {
        audioSrc.PlayOneShot(steamEngineHurt);
    }

    public static void PlayDoorOpen()
    { 
        audioSrc.PlayOneShot(doorOpen);
    }
}
