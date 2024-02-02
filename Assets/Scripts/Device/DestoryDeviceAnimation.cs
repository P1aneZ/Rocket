using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceAnimation : MonoBehaviour
{    
    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void DeviceHurt()
    {
        anim.SetTrigger("hurt");
    }
}
