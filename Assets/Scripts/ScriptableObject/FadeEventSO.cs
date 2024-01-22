using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Event/FadeEventSO")]
public class FadeEventSO : ScriptableObject
{
    //创建淡入淡出事件，传递的参数有，颜色，时间，是淡入还是淡出
    public UnityAction<Color, float, bool> OnEventRaised;

    //逐渐变黑
    public void FadeIn(float duration)
    {
        RaiseEvent(Color.black, duration, true);
    }

    //逐渐变透明
    public void FadeOut(float duration)
    {
        RaiseEvent(Color.clear, duration, false);
    }

    //调用事件
    public void RaiseEvent(Color target,float duration, bool fadeIn)
    {
        OnEventRaised(target, duration, fadeIn); 
    }
}
