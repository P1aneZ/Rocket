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

    int a;//女敌人受伤时随机播放第a种音效
    
   
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
        
    }

 

    public static void PlayEnemyAttackFemale()
    {
        audioSrc.PlayOneShot(enemyAttackFemale);
    }

    public static void PlayEnemyDeadFemale()
    {
        audioSrc.PlayOneShot(enemyDeadFemale);
    }

    public  void PlayEnemyHurtFemale()
    {
        a = Random.Range(1, 4);//随机播放三种女敌人受伤音效的一种
        if (a == 1)
        {
            enemyHurtFemale1 = Resources.Load<AudioClip>("Enemy_Hurt_Female1");
            if (enemyHurtFemale1)
            {
                audioSrc.PlayOneShot(enemyHurtFemale1);
                Debug.Log("女人受伤1");
            }
            
        }
        else if (a == 2)
        {
            enemyHurtFemale2 = Resources.Load<AudioClip>("Enemy_Hurt_Female2");
            if(enemyHurtFemale2)
            {
                audioSrc.PlayOneShot(enemyHurtFemale2);
                Debug.Log("女人受伤2");
            }
           
        }
        else if (a == 3)
        {
            enemyHurtFemale3 = Resources.Load<AudioClip>("Enemy_Hurt_Female3");
            if (enemyHurtFemale3)
            {
                audioSrc.PlayOneShot(enemyHurtFemale3);
                Debug.Log("女人受伤3");
            }
            
        }
    }

   
}
