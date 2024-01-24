using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceSound : MonoBehaviour
{
    //定义音效
    public static AudioSource audioSrc;//定义播放器

    //摧毁装置有关音效
    public static AudioClip steamEngineExplosion;
    public static AudioClip steamEngineHurt;
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取摧毁装置音效文件
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
