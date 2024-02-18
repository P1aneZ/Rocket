using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider slider1;
    public Slider slider2;

    private void Start()
    {
        float slidervalue1;
        audioMixer.GetFloat("BGM", out slidervalue1);
        slider1.value = slidervalue1;
        float slidervalue2;
        audioMixer.GetFloat("FX", out slidervalue2);
        slider2.value = slidervalue2;
    }

    public void SetVolume(float Value)
    {
        audioMixer.SetFloat("BGM", Value);
    }

    public void SetVolume2(float Value)
    {
        audioMixer.SetFloat("FX", Value);
    }
}
