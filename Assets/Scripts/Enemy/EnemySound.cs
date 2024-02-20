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
    
    public static AudioClip enemyHurtFemale;

    
    
   
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取女敌人音效文件
        enemyAttackFemale = Resources.Load<AudioClip>("Enemy_Attack_Female");
        enemyDeadFemale = Resources.Load<AudioClip>("Enemy_Dead_Female");
        
        enemyHurtFemale = Resources.Load<AudioClip>("Enemy_Hurt_Female");
        
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
        audioSrc.PlayOneShot(enemyHurtFemale);
        Debug.Log("女人受伤");                
    }

   
}
