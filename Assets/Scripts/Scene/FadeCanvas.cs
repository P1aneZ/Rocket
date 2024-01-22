using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    [Header("�¼�����")]
    //�������뵭���¼���ע���Ӧ����
    public FadeEventSO fadeEvent;

    //��ȡһ�����ͼ��
    public Image fadeImage;

    private void OnEnable()
    {
        fadeEvent.OnEventRaised += OnFadeEvent;
    }

    private void OnDisable()
    {
        fadeEvent.OnEventRaised -= OnFadeEvent;
    }

    private void OnFadeEvent(Color target,float duration,bool fadeIn)
    {
        //����durationʱ�䣬�������Ŀ����ɫ
        fadeImage.DOBlendableColor(target, duration);
    }
}
