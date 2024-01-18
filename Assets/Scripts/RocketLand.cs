using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLand : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private Rigidbody2D rb;

    [Header("����ʱ��")]
    public float landDuration = 3.0f;
    public float supplyDuration = 3.0f;
    private float landTime,supplyTime;

    [Header("�ж��Ƿ�ɹ�")]
    public bool isLand;//�ɹ���½
    public bool isSupplied;//�ɹ�����
    public bool isDestroyed;//�ɹ��ݻ�


    private void Awake()
    {
        //��ȡ���
        rb = GetComponent<Rigidbody2D>();
        physicsCheck = GetComponent<PhysicsCheck>();
        supplyTime = 0;
        landTime = 0;
    }
    void Update()
    {
        if (landTime > 0)landTime -= Time.deltaTime;
        if (supplyTime > 0)supplyTime -= Time.deltaTime;
        Land();
        Destroy();
        Supply();
    }
    private void Land() //��⵽����½����ײ��ִ�еĺ���
    {
        if (physicsCheck.isWithLand)//�����ж�����½װ�÷�Χ�� 
        {
            //��ʼ����ʱ����ʼ��ʱ
            if(landTime==0)landTime = landDuration;
            if (landTime <= 0&&physicsCheck.isWithLand)//��ʱʱ�䵽�һ����Ȼ����½װ�÷�Χ��
            {
                isLand = true;//�ж��ɹ���½
                landTime = 0;
            }
            
            /*transform.position = new Vector3(-5f, 0, 0); 
            rb.velocity = new Vector3(0,0,0);*/
        }
        
    }

    private void Supply()
    {
        if (physicsCheck.isWithSupplyDevice)//�����߼�ͬLand();
        {
            if(supplyTime==0)supplyTime = supplyDuration;
            if (supplyTime <= 0 && physicsCheck.isWithSupplyDevice)
            {
                isSupplied = true;
                supplyTime = 0;
            }
        }
    }

    private void Destroy()
    {
        if(physicsCheck.isWithDestroyDevice)
        {
            isDestroyed = true;//�ж�Ϊ�Ѿ��ݻ�
        }
    }
}
