using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceAnimation : MonoBehaviour
{    
    public Animator anim;

    private Character character;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        character = GetComponent<Character>();
    }

    void Update()
    {
        SetAnimation();
    }

    public void SetAnimation()
    {
        anim.SetBool("isDead", character.isDead);
    }

    public void DeviceHurt()
    {
        anim.SetTrigger("hurt");
    }

    public void DestoryAfterDead()
    {
        Destroy(this.gameObject);
    }
}
