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

    private void Update()
    {
        rocketBottomPosition = transform.position;
        //ֻ�ı�yֵ
        rocketBottomPosition.y = transform.position.y - 1;
    }

    public void PlayEffect()
    {
        //����������Ч
        Instantiate(fireParticlesEffect, rocketBottomPosition, Quaternion.identity);
        finishPlayEffect = true;
    }

}
