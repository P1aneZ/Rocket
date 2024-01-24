using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SliderController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume(float Value)
    {
        audioMixer.SetFloat("BGM", Value);
    }

    public void SetVolume2(float Value)
    {
        audioMixer.SetFloat("FX", Value);
    }
}
