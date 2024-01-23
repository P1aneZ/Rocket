using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAnimation : MonoBehaviour
{
    //��ȡ�������
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
