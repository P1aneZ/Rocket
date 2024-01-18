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

    //�������ײ�������
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

    //��ȡ����ƶ�����
    private RocketMove rocketMove;
    //��ȡ������Ч��������
    private FireParticlesEffect fireEffect;

    //�������
    private float rocketHalfLength = 1;

    //��ʱ��
    private float playCounter;
    //�������һ�λ�
    public float fireAppearAgainTime;

    //�Ƿ��ǵ�һ�β�����Ч
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

        //��ʱ������ʱ
        if (!firstPlay)
            playCounter -= Time.deltaTime;
    }

    public void PlayEffect()
    {
        if(playCounter < 0 || firstPlay)
        {
            //����������Ч
            Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
            firstPlay = false;
            playCounter = fireAppearAgainTime;
        }

    }

    private void ControlFireAngle()
    {
        //�������ײ����ĵ������
        rocketBottomPosition = transform.position;

        rocketMove.direction = transform.position.normalized;

        //����ƫ��ֵ
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;

        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //����Ч������ͻ���ƶ������෴
        fireParticlesEffect.transform.right = transform.up;
    }

}
