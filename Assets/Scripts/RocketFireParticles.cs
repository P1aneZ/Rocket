using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketFireParticles : MonoBehaviour
{
    //获得火焰粒子
    public GameObject fireParticlesEffect;
    //是否播放完一遍火焰粒子特效
    public bool finishPlayEffect;
    //计算火箭底部的坐标
    private Vector3 rocketBottomPosition;

    private void Update()
    {
        rocketBottomPosition = transform.position;
        //只改变y值
        rocketBottomPosition.y = transform.position.y - 1;
    }

    public void PlayEffect()
    {
        //播放粒子特效
        Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
        finishPlayEffect = true;
    }

}
