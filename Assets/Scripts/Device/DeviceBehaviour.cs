using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject rocket;
    private GameObject launchDevice;

    private RocketLand rocketLand;

    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        launchDevice = GameObject.Find("���װ��");
        TakeOff();//���
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void TakeOff()
    {
        rocket.transform.position=launchDevice.transform.position;//����������긳ֵΪ���װ�õ�����
        //thisָ��ǰ��
    }

    private void CheckSupply()
    {
        if(rocketLand.isSupplied)
        {
            //ִ�в����Ķ���
            GetComponent<RocketLand>().isSupplied = false;
        }

    }

    private void CheckDestroy()
    {
        if(rocketLand.isDestroyed)
        {
            //ִ�дݻٵĶ���
            GetComponent<RocketLand>().isDestroyed = false;
        }
    }

    private void CheckLand()
    {
        if (rocketLand.isLand)
        {
            //ִ����½�ĺ���
            GetComponent<RocketLand>().isLand=false;
        }
    }
}
