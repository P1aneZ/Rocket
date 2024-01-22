using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/FadeEventSO")]
public class FadeEventSO : ScriptableObject
{
    //�������뵭���¼������ݵĲ����У���ɫ��ʱ�䣬�ǵ��뻹�ǵ���
    public UnityAction<Color, float, bool> OnEventRaised;

    //�𽥱��
    public void FadeIn(float duration)
    {
        RaiseEvent(Color.black, duration, true);
    }

    //�𽥱�͸��
    public void FadeOut(float duration)
    {
        RaiseEvent(Color.clear, duration, false);
    }

    //�����¼�
    public void RaiseEvent(Color target,float duration, bool fadeIn)
    {
        OnEventRaised(target, duration, fadeIn); 
    }
}
