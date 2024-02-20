using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    [Header("²¥·ÅÆ÷")]
    public static AudioSource FX;

    [Header("UIÒôÐ§")]
    public AudioClip click;
    public AudioClip completed;
    public AudioClip failed;

    public void PlayClick()
    {
        FX.clip = click;
        FX.Play();
    }

    public void PlayCompleted()
    {
        FX.clip = completed;
        FX.Play();
    }

    public void PlayFailed()
    {
        FX.clip = failed;
        FX.Play();
    }
}
