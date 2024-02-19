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
    public static AudioClip enemyHurtFemale1;
    public static AudioClip enemyHurtFemale2;
    public static AudioClip enemyHurtFemale3;

    int a;//Ů��������ʱ������ŵ�a����Ч
    
   
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡŮ������Ч�ļ�
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
        a = Random.Range(1, 4);//�����������Ů����������Ч��һ��
        if (a == 1)
        {
            enemyHurtFemale1 = Resources.Load<AudioClip>("Enemy_Hurt_Female1");
            if (enemyHurtFemale1)
            {
                audioSrc.PlayOneShot(enemyHurtFemale1);
                Debug.Log("Ů������1");
            }
            
        }
        else if (a == 2)
        {
            enemyHurtFemale2 = Resources.Load<AudioClip>("Enemy_Hurt_Female2");
            if(enemyHurtFemale2)
            {
                audioSrc.PlayOneShot(enemyHurtFemale2);
                Debug.Log("Ů������2");
            }
           
        }
        else if (a == 3)
        {
            enemyHurtFemale3 = Resources.Load<AudioClip>("Enemy_Hurt_Female3");
            if (enemyHurtFemale3)
            {
                audioSrc.PlayOneShot(enemyHurtFemale3);
                Debug.Log("Ů������3");
            }
            
        }
    }

   
}
