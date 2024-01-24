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
        int a = Random.Range(1, 4);//�����������Ů����������Ч��һ��
        if (a == 1)
            audioSrc.PlayOneShot(enemyHurtFemale1);
        else if (a == 2)
            audioSrc.PlayOneShot(enemyHurtFemale2);
        else if (a == 3)
            audioSrc.PlayOneShot(enemyHurtFemale3);
    }
}