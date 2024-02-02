using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LandDevice : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private GameObject rocket;

    [Header("����ʱ��")]
    public float landDuration = 3.0f;

    public float landTime;

    [Header("�ж��Ƿ�ɹ�")]
    public bool isLand = false;//�ɹ���½


    //�ɹ���½�¼�
    public UnityEvent Pass;

    private void Awake()
    {
        //��ȡ���
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();

        landTime = landDuration;
    }
    void Update()
    {
        IfLand();
    }
    private void IfLand() //��⵽����½����ײ��ִ�еĺ���
    {
        if (physicsCheck.isWithLand)//�����ж�����½װ�÷�Χ�� 
        {
            if (landTime > 0)
            {
                landTime -= Time.deltaTime;
            }

            if (landTime <= 0)//��ʱʱ�䵽�һ����Ȼ����½װ�÷�Χ��
            {
                isLand = true;//�ж��ɹ���½
                Pass?.Invoke();//�����¼�

            }            
        }
        else
        {
            landTime = landDuration;
        }

    }
}
