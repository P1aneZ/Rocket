using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    //定义音效
    public static AudioSource audioSrc;//定义播放器

    //敌人相关音效
    public static AudioClip enemyAttackFemale;
    public static AudioClip enemyDeadFemale;
    public static AudioClip enemyHurtFemale1;
    public static AudioClip enemyHurtFemale2;
    public static AudioClip enemyHurtFemale3;
    public static AudioClip enemyWalkingGrass;
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取女敌人音效文件
        enemyAttackFemale = Resources.Load<AudioClip>("Enemy_Attack_Female");
        enemyDeadFemale = Resources.Load<AudioClip>("Enemy_Dead_Female");
        enemyHurtFemale1 = Resources.Load<AudioClip>("Enemy_Hurt_Female1");
        enemyHurtFemale2 = Resources.Load<AudioClip>("Enemy_Hurt_Female2");
        enemyHurtFemale3 = Resources.Load<AudioClip>("Enemy_Hurt_Female3");
        enemyWalkingGrass=Resources.Load<AudioClip>("Enemy_Walking_Grass");
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public static void PlayEnemyWalkingGrass()
    {
        audioSrc.PlayOneShot(enemyWalkingGrass);
    }
}
