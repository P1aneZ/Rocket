using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMove : MonoBehaviour
{
    private Rigidbody2D rb;
    //��ȡ��Ч����
    private RocketFireParticles rocketFireParticles;

    [Header("��������")]
    public float pushForce;
    public Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //��ȡ��Ч����
        rocketFireParticles = GetComponent<RocketFireParticles>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowMouseRotate();
        FollowMouseMove();
    }

    private void FollowMouseRotate()//������Rocket���������ת
    {
            //��ȡ���λ�ã������������Ļ����,Z��Ϊ0�����ﲻ��ת�� 
            Vector3 mouse = Input.mousePosition;
            //��ȡ������꣬����������������꣬��Ҫת��Ϊ��Ļ����
            Vector3 obj = Camera.main.WorldToScreenPoint(transform.position);
            //��Ļ��������������õ����ͻ��֮�����������
            direction = mouse - obj;
            //��z�ḳֵΪ0������ƽ��ռ���
            direction.z = 0f;
            //��Ŀ���������ȱ�Ϊ1������ֻ��Ҫ�������򣬲���Ҫ���ȣ����Ա��1.
            direction = direction.normalized;
            //���������y����Ŀ������һ�£��ﵽ��תЧ��
            transform.up = direction;        
    }

    private void FollowMouseMove()
    {

        if (Input.GetMouseButton(0))//������������ʱ
        {
            //����������Ч����
            rocketFireParticles.finishPlayEffect = false;

            //����Rocketһ��������귽�����
            rb.AddForce(transform.up * pushForce, ForceMode2D.Force);
        }
        else
        {
            if (!rocketFireParticles.finishPlayEffect)
            {
                rocketFireParticles.PlayEffect();
            }
        }

    }
}
