using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SupplyDevice : MonoBehaviour
{
    private GameObject rocket;
    private PhysicsCheck physicsCheck;

    //��ȡ����ʱUI
    public GameObject CounterUI;
    public TMP_Text CounterText;

    [Header("����ʱ��")]
    public float supplyDuration = 3.0f;
    public float supplyTime;

    [Header("�ж��Ƿ�ɹ�")]
    public bool isSupplied = false;//�ɹ�����

    void Start()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();
        supplyTime = supplyDuration;

        CounterText = CounterUI.GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        IfSupply();
    }

    private void IfSupply()
    {
        //����ʱ,����һλС��
        CounterText.text = supplyTime.ToString("0.0");
        //�򿪵���ʱ
        CounterUI.SetActive(true);

        if (physicsCheck.isWithSupplyDevice)
        {
            if (supplyTime > 0)
            {
                supplyTime-=Time.deltaTime;
            }
            if (supplyTime <= 0 )
            {
                isSupplied = true;
                //�������

                //�رյ���ʱ
                CounterUI.SetActive(false);
            }
        }
        else
        {
            supplyTime = supplyDuration;

            //�رյ���ʱ
            CounterUI.SetActive(false);
        }
    }
}
