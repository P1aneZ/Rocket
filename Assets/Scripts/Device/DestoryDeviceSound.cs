using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceSound : MonoBehaviour
{
    //������Ч
    public static AudioSource audioSrc;//���岥����

    //�ݻ�װ���й���Ч
    public static AudioClip steamEngineExplosion;
    public static AudioClip steamEngineHurt;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡ�ݻ�װ����Ч�ļ�
        steamEngineExplosion = Resources.Load<AudioClip>("SteamEngine_Explosion");
        steamEngineHurt = Resources.Load<AudioClip>("SteamEngine_Hurt");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlaySteamEngineExplosion()
    {
        audioSrc.PlayOneShot(steamEngineExplosion);
    }

    public static void PlaySteamEngineHurt()
    {
        audioSrc.PlayOneShot(steamEngineHurt);
    }
}
