using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundMale : MonoBehaviour
{
    //定义音效
    public static AudioSource audioSrc;//定义播放器

    //敌人相关音效
    public static AudioClip enemyAttackmale;
    public static AudioClip enemyDeadmale;
    public static AudioClip enemyHurtmale;

    public static AudioClip enemyWalkingGrass;
    public static AudioClip enemyWalkingStreet;
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();



        //读取男敌人音效文件
        enemyAttackmale = Resources.Load<AudioClip>("Enemy_Attack_male");
        enemyDeadmale = Resources.Load<AudioClip>("Enemy_Dead_male");
        enemyHurtmale = Resources.Load<AudioClip>("Enemy_Hurt_male");
        enemyWalkingGrass = Resources.Load<AudioClip>("Enemy_Walking_Grass");
        enemyWalkingStreet = Resources.Load<AudioClip>("Enemy_Walking_Street");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlayEnemyAttackmale()
    {
        audioSrc.PlayOneShot(enemyAttackmale);
    }

    public static void PlayEnemyDeadmale()
    {
        audioSrc.PlayOneShot(enemyDeadmale);
    }

    public static void PlayEnemyHurtmale()
    {

        audioSrc.PlayOneShot(enemyHurtmale);

    }

    public static void PlayEnemyWalkingGrass()
    {
        audioSrc.PlayOneShot(enemyWalkingGrass);
    }

    public static void PlayEnemyWalkingStreet()
    {
        audioSrc.PlayOneShot(enemyWalkingStreet);
    }
}
