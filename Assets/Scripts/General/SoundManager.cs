using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;


public class SoundManager : MonoBehaviour
{
    //定义音效
    public static AudioSource audioSrc;//定义播放器
   
    //火箭相关音效
    public static AudioClip rocketMoving;
    public static AudioClip rocketExplosion1;
    public static AudioClip rocketExplosion2;
    public static AudioClip rocketExplosion3;
    public static AudioClip rocketReady;
    public static AudioClip rocketHit;

    //敌人相关音效
    public static AudioClip enemyAttackFemale;
    public static AudioClip enemyDeadFemale;
    public static AudioClip enemyHurtFemale1;
    public static AudioClip enemyHurtFemale2;
    public static AudioClip enemyHurtFemale3;

    //摧毁装置有关音效
    public static AudioClip steamEngineExplosion;
    public static AudioClip steamEngineHurt;

    //开门音效
    public static AudioClip doorOpen;

    // Start is called before the first frame update
    void Start()
    {
       //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取火箭音效文件
        rocketMoving = Resources.Load<AudioClip>("Rocket_Moving");
        rocketExplosion1 = Resources.Load<AudioClip>("Rocket_Explosion1");
        rocketExplosion2 = Resources.Load<AudioClip>("Rocket_Explosion2");
        rocketExplosion3 = Resources.Load<AudioClip>("Rocket_Explosion3");
        rocketHit = Resources.Load<AudioClip>("Rocket_Hit");

        //读取女敌人音效文件
        enemyAttackFemale = Resources.Load<AudioClip>("Enemy_Attack_Female");
        enemyDeadFemale = Resources.Load<AudioClip>("Enemy_Dead_Female");
        enemyHurtFemale1 = Resources.Load<AudioClip>("Enemy_Hurt_Female1");
        enemyHurtFemale2 = Resources.Load<AudioClip>("Enemy_Hurt_Female2");
        enemyHurtFemale3 = Resources.Load<AudioClip>("Enemy_Hurt_Female3");

        //读取摧毁装置音效文件
        steamEngineExplosion= Resources.Load<AudioClip>("SteamEngine_Explosion");
        steamEngineHurt = Resources.Load<AudioClip>("SteamEngine_Hurt");

        //读取开门音效文件
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
        int a = Random.Range(1, 4);//随机播放三种爆炸音效中的一种
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
        int a = Random.Range(1, 4);//随机播放三种女敌人受伤音效的一种
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
