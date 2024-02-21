using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FXManager : MonoBehaviour
{
    [Header("������")]
    public AudioSource FX;

    [Header("UI��Ч")]
    public AudioClip click;
    public AudioClip completed;
    public AudioClip failed;

    [Header("�¼�����")]
    public VoidEventSO ClickDown;
    public VoidEventSO Pass;
    public VoidEventSO Fail;

    private void OnEnable()
    {
        ClickDown.OnEventRaised += PlayClick;
        Pass.OnEventRaised += PlayCompleted;
        Fail.OnEventRaised += PlayFailed;
    }

    private void OnDisable()
    {
        ClickDown.OnEventRaised -= PlayClick;
        Pass.OnEventRaised -= PlayCompleted;
        Fail.OnEventRaised -= PlayFailed;
    }

    public void PlayClick()
    {
        FX.clip = click;
        if(FX.clip != null )
            FX.Play();
        Debug.Log("���");
    }

    public void PlayCompleted()
    {
        FX.clip = completed;
        if (FX.clip != null)
            FX.Play();
    }

    public void PlayFailed()
    {
        FX.clip = failed;
        if (FX.clip != null)
            FX.Play();
    }
}
