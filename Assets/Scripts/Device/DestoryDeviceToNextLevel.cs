using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    public bool isDestroyed;//�Ƿ�ݻ�
         
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//�ɹ��ݻ�
        //�����¼�
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("ͬ���ھ�");
            isDestroyed = true;
            //�����¼�
        }
    }
}
