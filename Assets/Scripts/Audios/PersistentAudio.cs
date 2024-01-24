using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio : MonoBehaviour
{ 
    public AudioSource PlayTheme;
    public AudioSource PlayClick;

    [Header("�¼�����")]
    public VoidEventSO beginPlayGame;
    public VoidEventSO clickButton;

    private void OnEnable()
    {
        beginPlayGame.OnEventRaised += StopThemeMusic;
        clickButton.OnEventRaised += playClick;
    }

    private void OnDisable()
    {
        beginPlayGame.OnEventRaised -= StopThemeMusic;
        clickButton.OnEventRaised -= playClick;
    }

    private void StopThemeMusic()
    {
        PlayTheme.Stop();
    }

    private void playClick()
    {
        Debug.Log("�������");
        PlayClick.Play();
    }
}
