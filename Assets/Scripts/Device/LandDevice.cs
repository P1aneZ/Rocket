using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class LandDevice : MonoBehaviour
{
    private PhysicsCheck physicsCheck;
    private GameObject rocket;
    //��ȡ����ʱUI
    public GameObject CounterUI;
    public TMP_Text CounterText;  

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
        CounterText = CounterUI.GetComponent<TMP_Text>();

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
            //����ʱ,����һλС��
            CounterText.text = landTime.ToString("0.0");
            //�򿪵���ʱ
            CounterUI.SetActive(true);

            if (landTime > 0)
            {
                landTime -= Time.deltaTime;
            }

            if (landTime <= 0)//��ʱʱ�䵽�һ����Ȼ����½װ�÷�Χ��
            {
                CounterUI.SetActive(false);//�رյ���ʱ
                isLand = true;//�ж��ɹ���½
                Pass?.Invoke();//�����¼�

            }            
        }
        else
        {
            landTime = landDuration;

            //�رյ���ʱ
            CounterUI.SetActive(false);
        }

    }
}
