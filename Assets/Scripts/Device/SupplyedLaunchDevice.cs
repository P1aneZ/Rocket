using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class SupplyedLaunchDevice : MonoBehaviour
{
    private GameObject rocket;
    private PhysicsCheck physicsCheck;
    public  GameObject supplyDevice;

    [Header("����ʱ��")]
    public float landDuration = 3.0f;
    public float landTime;

    [Header("�ж��Ƿ�ɹ�")]
    public bool isLand = false;//�ɹ���½

    //�ɹ���½�¼�
    public UnityEvent Pass;
    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck= rocket.GetComponent<PhysicsCheck>();  
        
        TakeOff();//���
    }
    void Update()
    {
        if (supplyDevice.GetComponent<SupplyDevice>().isSupplied)
        {
            IfLand();
        }
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
    private void TakeOff()
    {
        rocket.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        //����������긳ֵΪ���װ�õ�����                                                                                                                                                                 //thisָ��ǰ��
    }
}
