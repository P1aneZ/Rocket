using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    //������Ч
    public static AudioSource audioSrc;//���岥����

    //���������Ч
    public static AudioClip enemyAttackFemale;
    public static AudioClip enemyDeadFemale;
    
    public static AudioClip enemyHurtFemale;

    
    
   
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡŮ������Ч�ļ�
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
        Debug.Log("Ů������");                
    }

   
}
