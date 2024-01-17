using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketFireParticles : MonoBehaviour
{
    //��û�������
    public GameObject fireParticlesEffect;
    //�Ƿ񲥷���һ�����������Ч
    public bool finishPlayEffect;
    //�������ײ�������
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

    //��ȡ����ƶ�����
    private RocketMove rocketMove;
    //�������
    private float rocketHalfLength = 1;

    private void Awake()
    {
        rocketMove = GetComponent<RocketMove>();
        bottomOffset = new Vector3();
    }

    private void Update()
    {
        //�������ײ����ĵ������
        rocketBottomPosition = transform.position;

        //����ƫ��ֵ
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y))/rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        
        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //����Ч������ͻ���ƶ������෴
        fireParticlesEffect.transform.right = rocketMove.direction;
    }

    public void PlayEffect()
    {
        //����������Ч
        Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
        finishPlayEffect = true;
    }

}
