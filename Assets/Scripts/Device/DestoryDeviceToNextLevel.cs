using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestoryDeviceToNextLevel : MonoBehaviour
{
    //�ɹ�ͨ���¼�
    public UnityEvent Pass;

    public bool isDestroyed;//�Ƿ�ݻ�
         
    public void CheckDestoryDeviceDead()
    {
        isDestroyed = true;//�ɹ��ݻ�
        //�����¼�
        Pass?.Invoke();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Rocket")
        {
            Debug.Log("ͬ���ھ�");
            this.gameObject.GetComponent<Character>().isDead = true;
            this.gameObject.GetComponent<Character>().OnDie?.Invoke();
            isDestroyed = true;
            //�����¼�
            Pass?.Invoke();
        }
    }
}
