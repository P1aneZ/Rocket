using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOffDeviceSound : MonoBehaviour
{
    public static AudioSource audioSrc;//���岥����

    public static AudioClip rocketReady;
    // Start is called before the first frame update
    void Start()
    {
        //��ȡ���������
        audioSrc = GetComponent<AudioSource>();

        rocketReady =Resources.Load<AudioClip>("Rocket_Ready");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayRocketReady()
    {
        audioSrc.PlayOneShot(rocketReady);
    }
}
