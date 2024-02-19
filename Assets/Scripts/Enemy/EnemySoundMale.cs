using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundMale : MonoBehaviour
{
    //������Ч
    public static AudioSource audioSrc;//���岥����

    //���������Ч
    public static AudioClip enemyAttackmale;
    public static AudioClip enemyDeadmale;
    public static AudioClip enemyHurtmale;

    
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡ�е�����Ч�ļ�
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
            Debug.Log("��������");
        }

    }

    
}
