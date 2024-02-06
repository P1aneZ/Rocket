using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketFireParticles : MonoBehaviour
{
    //��ȡ����ƶ�����
    private RocketMove rocketMove;
    //��ȡ������Ч��������
    //private FireParticlesEffect fireEffect;
    //��û�������
    public GameObject fireParticlesEffect;

    //�������ײ�������
    private Vector3 rocketBottomPosition;
    private Vector3 bottomOffset;

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
        //��ȡ�������ʼ������ײ������ĵ�ƫ��ֵ
        rocketMove = GetComponent<RocketMove>();
        //fireEffect = fireParticlesEffect.GetComponent<FireParticlesEffect>();
        bottomOffset = new Vector3();
    }

    private void Update()
    {
        //��������ĽǶ�
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
            Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.Euler(90, 90, 0));
            firstPlay = false;
            //���ü�ʱ��
            playCounter = fireAppearAgainTime;
        }

    }

    private void ControlFireAngle()
    {
        //�������ײ����ĵ������
        rocketBottomPosition = transform.position;

        //����ƫ��ֵ
        bottomOffset.x = (rocketMove.direction.x / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;
        bottomOffset.y = (rocketMove.direction.y / Mathf.Sqrt(rocketMove.direction.x * rocketMove.direction.x + rocketMove.direction.y * rocketMove.direction.y)) / rocketHalfLength;

        rocketBottomPosition.x = transform.position.x - bottomOffset.x;
        rocketBottomPosition.y = transform.position.y - bottomOffset.y;

        //����Ч������ͻ���ƶ������෴
        //fireParticlesEffect.transform.right = rocketMove.direction;
        //fireParticlesEffect.transform.rotation = Quaternion.Euler(fireParticlesEffect.transform.rotation.x, 90, 0);


    }

}
