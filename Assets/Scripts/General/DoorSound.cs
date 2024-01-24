using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    //定义音效
    public static AudioSource audioSrc;//定义播放器

    //开门音效
    public static AudioClip doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        //获取播放器组件
        audioSrc = GetComponent<AudioSource>();

        //读取开门音效文件
        doorOpen = Resources.Load<AudioClip>("Door_Open");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void PlayDoorOpen()
    {
        audioSrc.PlayOneShot(doorOpen);
    }
}
