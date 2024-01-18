using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketFireParticles : MonoBehaviour
{
    //获得火焰粒子
    public GameObject fireParticlesEffect;

    //计算火箭底部的坐标
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

    //获取火箭移动方向
    private RocketMove rocketMove;
    //获取粒子特效生命周期
    private FireParticlesEffect fireEffect;

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
        rocketMove = GetComponent<RocketMove>();
        fireEffect = fireParticlesEffect.GetComponent<FireParticlesEffect>();
        bottomOffset = new Vector3();
    }

    private void Update()
    {
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
            Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
            firstPlay = false;
            playCounter = fireAppearAgainTime;
        }

    }

    private void ControlFireAngle()
    {
        //计算火箭底部中心点的坐标
        rocketBottomPosition = transform.position;

        rocketMove.direction = transform.position.normalized;

        //计算偏移值
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;

        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //粒子效果方向和火箭移动方向相反
        fireParticlesEffect.transform.right = transform.up;
    }

}
