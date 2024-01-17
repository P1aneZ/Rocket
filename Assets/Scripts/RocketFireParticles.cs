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
    //是否播放完一遍火焰粒子特效
    public bool finishPlayEffect;
    //计算火箭底部的坐标
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

    //获取火箭移动方向
    private RocketMove rocketMove;
    //火箭半身长
    private float rocketHalfLength = 1;

    private void Awake()
    {
        rocketMove = GetComponent<RocketMove>();
        bottomOffset = new Vector3();
    }

    private void Update()
    {
        //计算火箭底部中心点的坐标
        rocketBottomPosition = transform.position;

        //计算偏移值
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y))/rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        
        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //粒子效果方向和火箭移动方向相反
        fireParticlesEffect.transform.right = rocketMove.direction;
    }

    public void PlayEffect()
    {
        //播放粒子特效
        Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
        finishPlayEffect = true;
    }

}
