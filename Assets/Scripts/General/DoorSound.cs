using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSound : MonoBehaviour
{
    //������Ч
    public static AudioSource audioSrc;//���岥����

    //������Ч
    public static AudioClip doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        //��ȡ������Ч�ļ�
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
