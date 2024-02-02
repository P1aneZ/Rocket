using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    public bool isDestroyed;//�Ƿ�ݻ�

    private GameObject rocket;
    private PhysicsCheck physicsCheck; 

    private void Start()
    {
        rocket = GameObject.Find("Rocket_0");
        physicsCheck = rocket.GetComponent<PhysicsCheck>();
    }

    private void Update()
    {
        IfDestroy();
    }
    public void IfDestroy()
    {
        if (physicsCheck.isWithDestroyDevice)
        {
            isDestroyed = true;//�ж�Ϊ�Ѿ��ݻ�
            //���������¼�
        }
    }
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//�ɹ��ݻ�
        //�����¼�
    }
}
