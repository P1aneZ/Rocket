using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDevice : MonoBehaviour
{
    private GameObject rocket;
    private PhysicsCheck physicsCheck;

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
    }

    // Update is called once per frame
    void Update()
    {
        IfSupply();
    }

    private void IfSupply()
    {
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
            }
        }
        else
        {
            supplyTime = supplyDuration;
        }
    }
}
