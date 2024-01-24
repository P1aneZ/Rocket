using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentAudio : MonoBehaviour
{ 
    public AudioSource PlayTheme;
    public AudioSource PlayClick;

    [Header("事件监听")]
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
        Debug.Log("点击了捏");
        PlayClick.Play();
    }
}
