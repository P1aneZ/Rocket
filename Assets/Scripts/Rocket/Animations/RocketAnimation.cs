using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    //获取动画组件
    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void PlayHurt()
    {
        anim.SetTrigger("hurt");
    }
}
