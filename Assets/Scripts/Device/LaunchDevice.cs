using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDevice : MonoBehaviour
{
    private GameObject rocket;
    // Start is called before the first frame update
    void Awake()
    {
        rocket = GameObject.Find("Rocket_0");
        
        TakeOff();//���
    }

    private void TakeOff()
    {
        rocket.transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
        //����������긳ֵΪ���װ�õ�����                                                                                                                                                                 //thisָ��ǰ��
    }
}
