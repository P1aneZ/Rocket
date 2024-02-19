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

    
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取男敌人音效文件
        enemyAttackmale = Resources.Load<AudioClip>("Enemy_Attack_Male");
        enemyDeadmale = Resources.Load<AudioClip>("Enemy_Dead_Male");
        enemyHurtmale = Resources.Load<AudioClip>("Enemy_Hurt_Female3");
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
        enemyHurtmale = Resources.Load<AudioClip>("Enemy_Hurt_Female3");
        if (enemyAttackmale != null)
        {
            audioSrc.PlayOneShot(enemyHurtmale);
            Debug.Log("男人受伤");
        }

    }

    
}
