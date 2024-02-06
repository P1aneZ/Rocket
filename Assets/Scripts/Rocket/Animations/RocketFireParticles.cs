using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketFireParticles : MonoBehaviour
{
    //获取火箭移动方向
    private RocketMove rocketMove;
    //获取粒子特效生命周期
    //private FireParticlesEffect fireEffect;
    //获得火焰粒子
    public GameObject fireParticlesEffect;

    //计算火箭底部的坐标
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

    //火箭半身长
    private float rocketHalfLength = 1;

    //计时器
    private float playCounter;
    //隔多久喷一次火
    public float fireAppearAgainTime;

    //是否是第一次播放特效
    private bool firstPlay = true;

    private void Awake()
    {
        //获取组件，初始化火箭底部与中心的偏移值
        rocketMove = GetComponent<RocketMove>();
        //fireEffect = fireParticlesEffect.GetComponent<FireParticlesEffect>();
        bottomOffset = new Vector3();
    }

    private void Update()
    {
        //调整火焰的角度
        ControlFireAngle();

        //计时器倒计时
        if (!firstPlay)
            playCounter -= Time.deltaTime;
    }

    public void PlayEffect()
    {
        if(playCounter < 0 || firstPlay)
        {
            //播放粒子特效
            Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.Euler(90, 90, 0));
            firstPlay = false;
            //重置计时器
            playCounter = fireAppearAgainTime;
        }

    }

    private void ControlFireAngle()
    {
        //计算火箭底部中心点的坐标
        rocketBottomPosition = transform.position;

        //计算偏移值
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;

        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //粒子效果方向和火箭移动方向相反
        //fireParticlesEffect.transform.right = rocketMove.direction;
        //fireParticlesEffect.transform.rotation = Quaternion.Euler(fireParticlesEffect.transform.rotation.x, 90, 0);


    }

}
